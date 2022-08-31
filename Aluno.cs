
internal class Aluno
{
    private int id;
    private string name;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }

    public Aluno(int id, string name)
    {
        Id= id;
        Name = name;
    }

    public bool PodeMatricular(Curso[] cursos)
    {
      bool matriculado = false;
      foreach(Curso curso in cursos){
        for(int i = 0; i < 12; i++){
          Disciplina t = curso.Disciplinas[i];
          for(int j = 0; j < 15; j++){
            if(t.Alunos[j].ToString() == Name){
              matriculado = true;
            } 
          }
        }
      }

      return !matriculado;
    }

}
