The `SearchAndRedact` sample shows how to redact the results of a search operation.

The `PDFContentExtractor` class is used to search for text in a PDF page.

The `PDFContentRedactor` class is used to redact content from a PDF page. Multiple strings can be redacted in one step by enclosing the `PDFContentRedactor.RedactArea` calls in a `PDFContentRedactor.BeginRedaction` / `PDFContentRedactor.ApplyRedaction` section. The actual redaction is executed when `PDFContentRedactor.ApplyRedaction` is called.
