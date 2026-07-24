using ConsolePlusLibrary.Core;
using FluentAssertions;
using System;
using System.Threading;
using Xunit;

namespace ConsolePlus.Tests.Unit
{
    // Helper (Core/Helper.cs) — process-global mutable state (MainToken/ExitCode/LastException),
    // shared by the whole ConsolePlus assembly. No production control in this test suite touches
    // it, but every test here saves and restores the original value so a parallel test class
    // (xUnit parallelizes across classes by default) never observes a mutated singleton.
    public class HelperTests
    {
        [Fact]
        public void ExitCode_holds_whatever_value_is_assigned()
        {
            int original = Helper.ExitCode;
            try
            {
                Helper.ExitCode = 42;
                Helper.ExitCode.Should().Be(42);
            }
            finally
            {
                Helper.ExitCode = original;
            }
        }

        [Fact]
        public void LastException_holds_whatever_exception_is_assigned()
        {
            Exception? original = Helper.LastException;
            try
            {
                var ex = new InvalidOperationException("probe");
                Helper.LastException = ex;
                Helper.LastException.Should().BeSameAs(ex);
            }
            finally
            {
                Helper.LastException = original;
            }
        }

        [Fact]
        public void LastException_can_be_cleared_back_to_null()
        {
            Exception? original = Helper.LastException;
            try
            {
                Helper.LastException = new Exception("probe");
                Helper.LastException = null;
                Helper.LastException.Should().BeNull();
            }
            finally
            {
                Helper.LastException = original;
            }
        }

        [Fact]
        public void MainToken_is_a_working_cancellation_token_source()
        {
            CancellationTokenSource original = Helper.MainToken;
            try
            {
                Helper.MainToken = new CancellationTokenSource();
                Helper.MainToken.Token.IsCancellationRequested.Should().BeFalse();

                Helper.MainToken.Cancel();
                Helper.MainToken.Token.IsCancellationRequested.Should().BeTrue();
            }
            finally
            {
                Helper.MainToken = original;
            }
        }
    }
}
