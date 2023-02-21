# MVC SRI Hash Test

**SRI (Subresource Integrity):** https://www.srihash.org/

This proof-of-concept projects adds a new MVC HtmlHelper method called `RenderSecureScript()`. The helper automatically calculates the sha384 hash for the requested script file, and returns a `<script>` tag with the hash.

```html
<script src="/script.js" integrity="sha384-SOMEHASHGOESHERE" crossorigin="anonymous"></script>
```

See /Services/ScriptsExtensionMethods.cs for the code. This code probably won't work in dotnet core, but I only need this for Framework at the moment.

This project also has a default Content-Security-Policy header defined in web.config.