using System;
using System.Collections.Generic;
using System.Text;

namespace ED_24_26
{
    class Aluno
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Aluno()
        {
            Id = -1;
            Name = "...";
        }

        public Aluno(int id)
        {
            Id = id;
            Name = "...";
        }
        public Aluno(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool PodeMatricular(Curso[] cursos)
        {
            int matriculadoDisciplina = 0;
            int aux = 0;
            bool podeMatricular;
            foreach (Curso curso in cursos)
            {
                for (int i = 0; i < 12; i++)
                {
                    Disciplina disciplina = curso.Disciplinas[i];
                    for (int j = 0; j < 15; j++)
                    {
                        if (disciplina.Alunos[j].Id == Id && disciplina.Alunos[j].Name == Name)
                        {
                            aux++;
                            matriculadoDisciplina++;
                        }
                        
                    }
                }
            }
            Console.WriteLine(aux);

            podeMatricular = matriculadoDisciplina <= 6;
            Console.WriteLine("PODE? " + podeMatricular);

            return podeMatricular;
        }
    }
}
