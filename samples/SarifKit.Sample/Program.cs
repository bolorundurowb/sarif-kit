using SarifKit.IO;

var input = args.Length > 0 ? args[0] : "sample.sarif";
var output = args.Length > 1 ? args[1] : "out.sarif";

using (var stream = File.OpenRead(input))
{
    var log = SarifReader.Read(stream);
    Console.WriteLine($"Runs: {log.Runs.Count}, Results: {log.Runs.Sum(r => r.Results?.Count ?? 0)}");

    using var outStream = File.Create(output);
    SarifWriter.Write(log, outStream);
    Console.WriteLine($"Wrote {output}");
}
