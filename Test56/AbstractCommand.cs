namespace Test56
{
    public abstract class AbstractCommand:ICommand
    {
        private string? description;
        private string? result;
        public string? Description { get => description; set => description = value; }
        public string? Result { get => result; set => result = value; }
        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);
    }
}