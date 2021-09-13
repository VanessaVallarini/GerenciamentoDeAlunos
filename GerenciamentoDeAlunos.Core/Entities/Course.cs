namespace GerenciamentoDeAlunos.Core.Entities
{
    public class Course : BaseEntity
    {
        public Course(string name, int credits)
        {
            Name = name;
            Credits = credits;
        }

        public string Name { get; private set; }
        public int Credits { get; private set; }

        public void Update(string name, int credits)
        {
            Name = name;
            Credits = credits;
        }
    }
}
