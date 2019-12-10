The `MultipleDigitalSignatures` sample shows how to sign a PDF file with multiple signatures.

The first signature is added in normal mode (like in all the other signature related samples), but for the subsequent signatures the document must be opened and saved in incremental update mode. 

After the first signature is applied only new signatures can be added later (or annotations depending on the restrictions), no other content is allowed otherwise the signatures are invalidated.

**NOTE:** This sample will not work properly with the evalaution version because of the evaluation message that is added to all PDF pages. This evaluation message causes the first signature to be invalidated when the second signature is applied.
