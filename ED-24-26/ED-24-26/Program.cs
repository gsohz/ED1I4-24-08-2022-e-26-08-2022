using System;

namespace ED_24_26
{
    class Program
    {

        static void Main(string[] args)
        {

            int key;

            Escola e = new Escola();
            int id;

            do
            {
                Console.WriteLine("\n0. Sair" +
                                    "\n1. Adicionar curso" +
                                    "\n2. Pesquisar curso (mostrar inclusive as disciplinas associadas)" +
                                    "\n3. Remover curso (não pode ter nenhuma disciplina associada)" +
                                    "\n4. Adicionar disciplina no curso" +
                                    "\n5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)" +
                                    "\n6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)" +
                                    "\n7. Matricular aluno na disciplina" +
                                    "\n8. Remover aluno da disciplina" +
                                    "\n9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado)");

                Console.Write("Opção: ");
                key = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (key)
                {
                    case 1:
                        Console.Write("Escolha o ID do curso: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Escolha o nome do curso: ");
                        string name = Console.ReadLine();

                        Curso c = new Curso(id, name);
                        Console.WriteLine(e.AdicionarCurso(c)?"Curso adicionado com sucesso" : "Não foi possível adicionar curso");
                        break;
                    case 2:
                        Console.WriteLine("Escolha o ID do curso que deseja pesquisar: ");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }
                        Console.Write("\nOpção: ");
                        id = int.Parse(Console.ReadLine());

                        Curso p = new Curso(id);
                        p = e.PesquisarCurso(p);
                        if(p.Id != -1)
                        {
                        Console.WriteLine("Id: " + p.Id + " Nome: " + p.Descricao);
                        }
                        else { Console.WriteLine("Não foi possível encontrar o curso pesquisado"); }
                        break;
                    case 3:
                        Console.WriteLine("Escolha o ID do curso que deseja remover: ");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }
                        Console.Write("\nOpção: ");
                        id = int.Parse(Console.ReadLine());

                        Curso q = new Curso(id);
                        q = e.PesquisarCurso(q);

                        e.RemoverCurso(q);
                        Console.WriteLine(e.RemoverCurso(q) ? "Curso removido" : "O curso não pode ser deletado porque possui disciplinas vinculadas a ele");
                        break;
                    case 4:
                        Console.WriteLine("Escolha o ID do curso que deseja adicionar uma disciplina: ");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }
                        Console.Write("\nOpção: ");
                        id = int.Parse(Console.ReadLine());

                        Curso t = new Curso(id);
                        t = e.PesquisarCurso(t);
                        if(t.Id != -1)
                        {
                            Console.Write("Escolha o ID da disciplina: ");
                            int id1 = int.Parse(Console.ReadLine());
                            Console.Write("Escolha o nome da disciplina: ");
                            string name1 = Console.ReadLine();

                            Disciplina d = new Disciplina(id1, name1);

                            bool resAddD = t.AdicionarDisciplina(d);

                            if (resAddD)
                            {
                                Console.WriteLine("Disciplina adicionada com sucesso no curso de " + t.Descricao );
                            } else { Console.WriteLine("Não foi possível adicionar disciplina no curso de " + t.Descricao); }
                        } else { Console.WriteLine("Curso não foi encontrado"); }
                        break;
                    case 5:
                        Console.WriteLine("Escolha o ID do curso que deseja pesquisar uma disciplina: ");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }
                        Console.Write("\nOpção: ");
                        id = int.Parse(Console.ReadLine());

                        Curso pesquisaCursoD = new Curso(id);
                        pesquisaCursoD = e.PesquisarCurso(pesquisaCursoD);

                        if(pesquisaCursoD.Id != -1)
                        {
                            Console.WriteLine("Escolha o ID da disciplina que deseja pesquisar: ");
                            foreach (Disciplina disciplina in pesquisaCursoD.Disciplinas)
                            {
                                if (disciplina.Id != -1)
                                {
                                    Console.WriteLine(disciplina.Id + ". " + disciplina.Descricao);
                                }
                            }
                            Console.Write("\nOpção: ");
                            int id2 = int.Parse(Console.ReadLine());


                            Disciplina pesquisaDisciplina = new Disciplina(id2);
                            pesquisaDisciplina = pesquisaCursoD.PesquisarDisciplina(pesquisaDisciplina);

                            if(pesquisaDisciplina.Id != -1)
                            {

                            Console.WriteLine("Disciplina: " + pesquisaDisciplina.Descricao);
                            Console.WriteLine("Alunos: ");

                                bool findA = false;
                            for (int i = 0; i < pesquisaDisciplina.Alunos.Length; i++)
                            {
                                if (pesquisaDisciplina.Alunos[i].Id != -1)
                                {
                                    Console.WriteLine("Id: " + pesquisaDisciplina.Alunos[i].Id + ", Nome: " + pesquisaDisciplina.Alunos[i].Name);
                                    if (findA == false) findA = true;
                                }
                            }

                            if(findA == false)
                                {
                                    Console.WriteLine("Nenhum aluno foi matriculado nessa disciplina ainda");
                                }
                            } else { Console.WriteLine("Disciplina não foi encontrada"); }
                        }
                        break;
                    case 6:
                        Console.WriteLine("Escolha o ID do curso que deseja remover uma disciplina: ");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }
                        Console.Write("\nOpção: ");
                        id = int.Parse(Console.ReadLine());

                        Curso pesquisaCursoRemovD = new Curso(id);
                        pesquisaCursoRemovD = e.PesquisarCurso(pesquisaCursoRemovD);

                        if(pesquisaCursoRemovD.Id != -1)
                        {

                            Console.WriteLine("Escolha o ID da disciplina que deseja remover: ");
                            foreach (Disciplina disciplina in pesquisaCursoRemovD.Disciplinas)
                            {
                                if (disciplina.Id != -1)
                                {
                                    Console.WriteLine(disciplina.Id + ". " + disciplina.Descricao);
                                }
                            }
                            Console.Write("\nOpção: ");
                            int id3 = int.Parse(Console.ReadLine());

                            Disciplina removDisciplina = new Disciplina(id3);
                            removDisciplina = pesquisaCursoRemovD.PesquisarDisciplina(removDisciplina);

                        
                            bool resRemovD = pesquisaCursoRemovD.RemoverDisciplina(removDisciplina);

                            if (resRemovD)
                            {
                                Console.WriteLine("Disciplina removida com sucesso");
                            } else { Console.WriteLine("Não foi possível remover a disciplina " + removDisciplina.Descricao + " ela possui alunos matriculados"); }
                        } else { Console.WriteLine("Cuso não encontrado"); }
                        break;
                    case 7:
                        Console.WriteLine("Faça o cadastro do aluno:");
                        Console.Write("\nInsira seu ID: ");
                        int idAluno = int.Parse(Console.ReadLine());
                        Console.Write("Insira seu nome: ");
                        string nomeAluno = Console.ReadLine();
                        Aluno addAluno = new Aluno(idAluno, nomeAluno);

                        bool resPodeAddAluno = addAluno.PodeMatricular(e.Cursos);

                        if (resPodeAddAluno)
                        {
                            Console.WriteLine("\nInsira o curso que ele vai frequentar digitando seu ID: ");
                            foreach(Curso curso in e.Cursos)
                            {
                                if(curso.Id != -1)
                                {
                                    Console.WriteLine(curso.Id + ". " + curso.Descricao);
                                }
                            }
                            Console.Write("\nOpção: ");
                            int idCurso = int.Parse(Console.ReadLine());
                            Curso pesquisaCursoA = new Curso(idCurso);
                            pesquisaCursoA = e.PesquisarCurso(pesquisaCursoA);

                            int aux = 0;
                            int auxId = -1;
                            bool podeMatricular = false;
                            foreach (Curso curso in e.Cursos)
                            {
                                for (int i = 0; i < 12; i++)
                                {
                                    Disciplina disciplina = curso.Disciplinas[i];
                                    for (int j = 0; j < 15; j++)
                                    {
                                        if (disciplina.Alunos[j].Id == addAluno.Id && disciplina.Alunos[j].Name == addAluno.Name)
                                        {
                                            aux++;
                                            auxId = curso.Id;
                                        }

                                    }
                                }
                            }
                            Console.WriteLine(aux);

                            if(pesquisaCursoA.Id != -1)
                            {
                                if (auxId == pesquisaCursoA.Id)
                                {
                                    podeMatricular = true;
                                }
                                else if (aux < 1)
                                {
                                    podeMatricular = true;
                                }
                                else podeMatricular = false;

                                Console.WriteLine("PODE? " + podeMatricular);


                                if (podeMatricular == true)
                                {
                                    Console.WriteLine("\nInsira a disciplina que ele vai cursar digitando seu ID: ");
                                    foreach (Disciplina disciplina in pesquisaCursoA.Disciplinas)
                                    {
                                        if (disciplina.Id != -1)
                                        {
                                            Console.WriteLine(disciplina.Id + ". " + disciplina.Descricao);
                                        }
                                    }
                                    Console.Write("\nOpção: ");
                                    int idDisciplina = int.Parse(Console.ReadLine());

                                    Disciplina pesquisaDisciplinaA = new Disciplina(idDisciplina);
                                    pesquisaDisciplinaA = pesquisaCursoA.PesquisarDisciplina(pesquisaDisciplinaA);

                                    if (pesquisaDisciplinaA.Id != -1)
                                    {
                                        bool resAddAluno = pesquisaDisciplinaA.MatricularAluno(addAluno);
                                        if (resAddAluno)
                                        {
                                            Console.WriteLine("Aluno adicionado com sucesso");
                                        }
                                        else { Console.WriteLine("Não foi possível adicionar o aluno"); }
                                    }
                                    else { Console.WriteLine("Disciplina não encontrada"); }
                                }
                                else { Console.WriteLine("O aluno já está matriculado em outro curso"); }
                            }
                            else { Console.WriteLine("O curso não foi encontrado"); }

                        } else
                        {
                            Console.WriteLine("O aluno não pôde ser matriculado");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Escolha o curso que o aluno frequenta selecionando seu ID: ");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }

                        Console.Write("\nOpção: ");
                        int idCursoRemovA = int.Parse(Console.ReadLine());
                        Curso pesquisaCursoRemovA = new Curso(idCursoRemovA);

                        pesquisaCursoRemovA = e.PesquisarCurso(pesquisaCursoRemovA);

                        if(pesquisaCursoRemovA.Id != -1)
                        {
                            Console.WriteLine("\nInsira a disciplina que o aluno que deseja desmatricular frequenta: ");
                            foreach (Disciplina disciplina in pesquisaCursoRemovA.Disciplinas)
                            {
                                if (disciplina.Id != -1)
                                {
                                    Console.WriteLine(disciplina.Id + ". " + disciplina.Descricao);
                                }
                            }
                            Console.Write("\nOpção: ");
                            int idDisciplinaRemovA = int.Parse(Console.ReadLine());

                            Disciplina pesquisaDisciplinaRemovA = new Disciplina(idDisciplinaRemovA);
                            pesquisaDisciplinaRemovA = pesquisaCursoRemovA.PesquisarDisciplina(pesquisaDisciplinaRemovA);

                            if(pesquisaDisciplinaRemovA.Id != -1)
                            {
                                Console.WriteLine("\nEscolha o ID do aluno que deseja desmatricular: ");
                                foreach(Aluno aluno in pesquisaDisciplinaRemovA.Alunos)
                                {
                                    if (aluno.Id != -1)
                                    {
                                        Console.WriteLine(aluno.Id + ". " + aluno.Name);
                                    }
                                }
                                Console.Write("\nOpção: ");
                                int idRemovA = int.Parse(Console.ReadLine());

                                Aluno removA = new Aluno(idRemovA);

                                bool resRemovA = pesquisaDisciplinaRemovA.DesmatricularAluno(removA);

                                if (resRemovA)
                                {
                                    Console.WriteLine("Aluno desmatriculado com sucesso");
                                }
                                else { Console.WriteLine("Não foi possível desmatricular o aluno"); }

                            } else { Console.WriteLine("Disciplina não encontrada"); }
                        } else { Console.WriteLine("Curso não foi encontrado"); }

                        break;
                    case 9:
                        Console.WriteLine("Insira o ID do curso que deseja pesquisar o aluno:");
                        foreach (Curso curso in e.Cursos)
                        {
                            if (curso.Id != -1)
                            {
                                Console.WriteLine(curso.Id + ". " + curso.Descricao);
                            }
                        }

                        Console.Write("\nOpção: ");
                        int idCursoPesquisaA = int.Parse(Console.ReadLine());
                        Curso pesquisaCursoPesquisaA = new Curso(idCursoPesquisaA);

                        pesquisaCursoPesquisaA = e.PesquisarCurso(pesquisaCursoPesquisaA);

                        if(pesquisaCursoPesquisaA.Id != -1)
                        {
                            Console.Write("Insira o ID do aluno que deseja pesquisar: ");
                            int idPesquisaAluno = int.Parse(Console.ReadLine());

                            Aluno pesquisaAluno = new Aluno(idPesquisaAluno);
                            bool find = false;

                            foreach(Disciplina disciplina in pesquisaCursoPesquisaA.Disciplinas)
                            {
                                for(int i = 0; i < 12; i++)
                                {
                                    if(disciplina.Alunos[i].Id == pesquisaAluno.Id)
                                    {
                                        Console.WriteLine("ID: " + disciplina.Alunos[i].Id + ", Nome: " + disciplina.Alunos[i].Name + ", Disciplina: " + disciplina.Descricao);
                                        find = true;
                                    }
                                }
                            }

                            if(find == false)
                            {
                                Console.WriteLine("O registro do aluno não foi encontrado");
                            }

                        } else { Console.WriteLine("Curso não encontrado"); }

                        
                        break;
                }
            } while (key != 0);
            
        }
    }
}
