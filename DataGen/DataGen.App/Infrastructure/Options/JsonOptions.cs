using CommandLine;

namespace DataGen.App.Infrastructure.Options
{
    class JsonOptions
    {
        [Value(0, MetaName = "file path", Required = true, HelpText = "Path to JSON template file")]
        public string FilePath { get; set; }

        [Option('c', "count", Required = false, HelpText = "Set number of items generated.", Default = 10000)]
        public int Count { get; set; }

        [Option('o', "outdir", Required = false, HelpText = "Output dir.")]
        public string OutputDir { get; set; }

        [Option('n', "name", Required = false, HelpText = "Output file name.")]
        public string OutputName { get; set; }
    }
}
