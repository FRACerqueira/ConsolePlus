# API Documentation Guide

This document explains how ConsolePlus's API documentation is generated and maintained.

## 🛠️ Tool Used

The API documentation is generated automatically using **[DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation)** version 1.2.5.

DefaultDocumentation is a tool that converts C# XML comments in the code into Markdown files, producing complete, navigable API documentation.

## 📁 Documentation Structure

```
docs/
├── api/                          # API documentation (generated automatically)
│   ├── ConsolePlus.md           # Assembly main page
│   ├── ConsolePlusLibrary.*.md  # Type and member pages
│   └── links.json               # External links (optional)
├── getting-started.md           # Manual guides
├── colors.md
└── ...
```

## ⚙️ Configuration

The DefaultDocumentation configuration lives in `src/ConsolePlus.csproj`:

```xml
<PropertyGroup>
	<!-- Generates the documentation XML file -->
	<GenerateDocumentationFile>True</GenerateDocumentationFile>
</PropertyGroup>

<!-- DefaultDocumentation ONLY in ReleaseDoc and on the net10.0 target -->
<ItemGroup Condition="'$(Configuration)' == 'ReleaseDoc' and '$(TargetFramework)' == 'net10.0'">
	<PackageReference Include="DefaultDocumentation" Version="1.2.5">
		<!-- <PrivateAssets>all</PrivateAssets>
		<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>. -->
	</PackageReference>
</ItemGroup>

<PropertyGroup Condition="'$(Configuration)' == 'ReleaseDoc' and '$(TargetFramework)' == 'net10.0'">
	<DefaultDocumentationFolder>..\docs\api</DefaultDocumentationFolder>
	<DefaultDocumentationGeneratedPages>Assembly, Namespaces, Classes, Interfaces, Events, Enums, Structs, Delegates</DefaultDocumentationGeneratedPages>
	<DefaultDocumentationFileNameFactory>NameAndMd5Mix</DefaultDocumentationFileNameFactory>
	<DefaultDocumentationGeneratedAccessModifiers>Public</DefaultDocumentationGeneratedAccessModifiers>
	<DefaultDocumentationAssemblyPageName>ConsolePlus</DefaultDocumentationAssemblyPageName>
	<DocIconUrl>https://raw.githubusercontent.com/FRACerqueira/ConsolePlus/main/icon.png</DocIconUrl>
	<DocIconWidth>120</DocIconWidth>
</PropertyGroup>
```

> ℹ️ After generation, an MSBuild task (`PrependDocIconHeader`) adds the header with the icon
> (`DocIconUrl` / `DocIconWidth`) to the top of every `.md` file generated in `docs/api`. Note that the
> `PrivateAssets`/`IncludeAssets` of the `PackageReference` are commented out in the actual project — left
> as a reference in case they ever need to be re-enabled, not as active configuration.

### Configuration Options

| Property | Value | Description |
|-------------|-------|-----------|
| `Condition` | `ReleaseDoc` + `net10.0` | **Documentation is generated ONLY on builds of the `ReleaseDoc` configuration on the net10.0 target** (not on `Release`, which is used to pack the NuGet without regenerating docs) |
| `DefaultDocumentationFolder` | `../docs/api` | Output folder for the Markdown files |
| `DefaultDocumentationGeneratedPages` | `Assembly, Namespaces, Classes, Interfaces, Events, Enums, Structs, Delegates` | Pages generated |
| `DefaultDocumentationFileNameFactory` | `NameAndMd5Mix` | Naming strategy for the generated files |
| `DefaultDocumentationGeneratedAccessModifiers` | `Public` | Documents public members only |
| `DefaultDocumentationAssemblyPageName` | `ConsolePlus` | Name of the assembly's main page (`ConsolePlus.md`) |
| `DocIconUrl` / `DocIconWidth` | icon.png / `120` | Icon header added to each generated `.md` file |

## 🔄 Regenerating the Documentation

The documentation is regenerated automatically every time you build the project in the
**ReleaseDoc** configuration for the **net10.0** target:

### Via Visual Studio
1. Open the solution in Visual Studio
2. Switch to the **ReleaseDoc** configuration
3. Build → Build Solution (Ctrl+Shift+B)
4. The Markdown files will be updated in `docs/api/`

**Note**: On **Debug** or **Release** builds (or on targets other than net10.0), the documentation
is **not** generated — `Release` is used only to pack the NuGet, without paying the cost of running DefaultDocumentation.

### Via Command Line
```bash
# From the repository root - ONLY ReleaseDoc generates documentation (net10.0 target)
dotnet build src/ConsolePlus.csproj -c ReleaseDoc -f net10.0

# Debug or Release builds do NOT generate documentation
dotnet build src/ConsolePlus.csproj -c Debug
dotnet build src/ConsolePlus.csproj -c Release
```

### Checking the Generated Files
```powershell
# Check generated files
Get-ChildItem ..\docs\api\*.md | Select-Object Name, LastWriteTime
```

## ✍️ Writing XML Comments

For the documentation to be generated correctly, add XML comments in the code:

```csharp
/// <summary>
/// Writes the specified text to the console.
/// </summary>
/// <param name="text">The text to write.</param>
/// <remarks>
/// This method supports inline markup for styling.
/// Example: <c>[red]Red text[/]</c>
/// </remarks>
/// <example>
/// <code>
/// ConsolePlus.WriteLine("Hello, [blue]World[/]!");
/// </code>
/// </example>
public static void WriteLine(string text)
{
	// implementation
}
```

### Supported XML Tags

| Tag | Usage |
|-----|-----|
| `<summary>` | Brief description of the member |
| `<param>` | Description of parameters |
| `<returns>` | Description of the return value |
| `<remarks>` | Additional information |
| `<example>` | Usage examples |
| `<code>` | Code blocks |
| `<see>` | Cross-references |
| `<seealso>` | See also |
| `<exception>` | Exceptions that may be thrown |

## 📝 Best Practices

1. **Be Concise**: Keep the `<summary>` to a single line
2. **Document Everything Public**: Every public member should have documentation
3. **Use Examples**: Add an `<example>` for complex methods
4. **Reference Other Types**: Use `<see cref="ClassName"/>` to create links
5. **Document Exceptions**: Use `<exception>` to document possible errors
6. **Markdown in Comments**: You can use Markdown inside `<remarks>`

## 🔍 Checking Quality

### Documentation Warnings

To make sure the entire public API is documented, you can enable warnings:

```xml
<PropertyGroup>
	<!-- Warnings for public members without documentation -->
	<GenerateDocumentationFile>True</GenerateDocumentationFile>
	<NoWarn>$(NoWarn);CS1591</NoWarn> <!-- Remove to see warnings -->
</PropertyGroup>
```

Remove `;CS1591` from `NoWarn` to see warnings about missing documentation.

## 🌐 External Links (Optional)

The `docs/api/links.json` file lets you configure external links for .NET Framework types:

```json
{
  "System": "https://learn.microsoft.com/en-us/dotnet/api/system",
  "System.Console": "https://learn.microsoft.com/en-us/dotnet/api/system.console",
  "System.Threading.Tasks": "https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks"
}
```

Add new types as needed to improve the documentation's links.

## 🚀 Publishing the Documentation

### GitHub Pages

To publish the documentation on GitHub Pages:

1. Configure the repository to use GitHub Pages
2. Point it to the branch/folder that contains the Markdown files
3. The documentation will be available at `https://username.github.io/ConsolePlus/`

### ReadTheDocs or Other Platforms

The generated Markdown files can be used with any documentation platform that supports Markdown.

## 🐛 Troubleshooting

### Documentation Is Not Being Generated

1. Check that `GenerateDocumentationFile` is `True`
2. Confirm that the DefaultDocumentation package is installed
3. Do a Clean + Rebuild of the solution
4. Check for build errors in the Output

### Build Warnings

If you see warnings related to DefaultDocumentation, check that:
- The package version is compatible with your .NET SDK
- All configuration properties are correct
- There are no conflicts with other analyzers

### Broken Links

If there are broken links in the documentation:
- Check that the referenced namespaces/types exist
- Update `links.json` for external types
- Use `<see cref="">` correctly in the XML comments

## 📦 Version Control

### What to Commit

✅ **Commit**:
- Configuration files (`ConsolePlus.csproj`)
- XML comments in the source code
- `links.json` (if used)

❓ **Optional**:
- Generated `.md` files in `docs/api/`
  - **Commit**: To keep a history and make PR review easier
  - **Don't commit**: If you prefer to generate them on demand (add `docs/api/*.md` to `.gitignore`)

The choice depends on the team's preference. Committing lets you see documentation changes in PRs.

## 🤝 Contributing

When submitting a Pull Request that adds or modifies public API:

1. ✅ Add complete XML comments
2. ✅ Include examples where appropriate
3. ✅ Regenerate the documentation (build)
4. ✅ Check that the `.md` files were updated
5. ✅ Review the generated documentation for quality

## 📚 Resources

- [DefaultDocumentation on GitHub](https://github.com/Doraku/DefaultDocumentation)
- [XML Documentation Comments (Microsoft)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)
- [Recommended XML Tags (Microsoft)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags)

---

**Last updated**: This guide was created together with the initial DefaultDocumentation setup for ConsolePlus.
