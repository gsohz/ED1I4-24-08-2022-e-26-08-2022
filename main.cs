using System;

class Program {
  public static void Main (string[] args) {
    int key = -1;

    Escola e = new Escola();
    int id;

    do {
      Console.WriteLine("\n0. Sair" +
                        "\n1.Adicionar curso" +
                        "\n2.Pesquisar curso (mostrar inclusive as disciplinas associadas)" +
                        "\n3.Remover curso (não pode ter nenhuma disciplina associada)" +
                        "\n4.Adicionar disciplina no curso" +
                        "\n5.Pesquisar disciplina (mostrar inclusive os alunos matriculados)" +
                        "\n6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)" +
                        "\n7. Matricular aluno na disciplina" +
                        "\n8. Remover aluno da disciplina" +
                        "\n9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado)");
      
                Console.Write("Opção: ");
                key = int.Parse(Console.ReadLine());

                Console.Clear();
      id = -2;

      switch(key){
        case 1:
            Console.Write("Escolha o ID do curso: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Escolha o nome do curso: ");
            String name = Console.ReadLine();
            
            Curso c = new Curso(id, name);
            e.AdicionarCurso(c);
           //Criar erros
          break;
        case 2:
            Console.Write("Escolha o ID do curso que deseja pesquisar: ");
            id = int.Parse(Console.ReadLine());
          
            Curso p = new Curso(id);
            p = e.PesquisarCurso(p);
            Console.WriteLine("Id: " + p.Id + "Nome: " + p.Descricao);
          //Criar erros
          break;
        case 3:
            Console.Write("Escolha o ID do curso que deseja remover: ");
            id = int.Parse(Console.ReadLine());
            
            Curso q = new Curso(id);
            Console.WriteLine(e.RemoverCurso(q)? "Curso removido" : "Curso não existe");
          //Criar erros
          break;
        case 4:
            Console.Write("Escolha o ID do curso que deseja adicionar uma disciplina: ");
            id = int.Parse(Console.ReadLine());

            Curso t = new Curso(id);
            t = e.PesquisarCurso(t);

            Console.Write("Escolha o ID da disciplina: ");
            int id1 = int.Parse(Console.ReadLine());
            Console.Write("Escolha o nome da disciplina: ");
            String name1 = Console.ReadLine();
          
            Disciplina d = new Disciplina(id1, name1);
          
            t.AdicionarDisciplina(d);
          break;
        case 5:
            Console.Write("Escolha o ID do curso que deseja pesquisar uma disciplina: ");
            id = int.Parse(Console.ReadLine());

            Curso m = new Curso(id);
            m = e.PesquisarCurso(m);

            Console.Write("Escolha o ID da disciplina que deseja pesquisar: ");
            int id2 = int.Parse(Console.ReadLine());

            Disciplina o = new Disciplina(id2);

          Console.WriteLine("Disciplina: " + o.Descricao);
          Console.WriteLine("Alunos: ");
          for(int i = 0; i < o.Alunos.Length; i++){
            Console.WriteLine(o.Alunos[i]);
          }
          break;
        case 6:
          break;
        case 7:
          Aluno a = new Aluno(1, "Fabio");
          Curso czin = new Curso(-1);

          czin = e.PesquisarCurso(czin);

          a.PodeMatricular(e.Cursos);
          
          break;
        case 8:
          break;
        case 9:
          break;
      }
    } while (key != 0);
  }
}