using Xunit;

// Run these tests in series (not in parallel) so crud methods don't trample on each other
[assembly: CollectionBehavior(DisableTestParallelization = true)]
