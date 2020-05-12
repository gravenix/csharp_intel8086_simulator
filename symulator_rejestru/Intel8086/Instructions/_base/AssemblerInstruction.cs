namespace symulator_rejestru.Intel8086.Instructions
{
    public interface AssemblerInstruction
    {
        void ExecuteCommand(Processor p);
    }
}
