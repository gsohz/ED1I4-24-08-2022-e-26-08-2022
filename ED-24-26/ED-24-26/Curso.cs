using System;
using System.Collections.Generic;
using System.Text;

namespace ED_24_26
{
    class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Disciplina[] Disciplinas { get => disciplinas; set => disciplinas = value; }

        public Curso(int id)
        {
            Id = id;
            disciplinas = new Disciplina[12];
            for (int i = 0; i < 12; i++)
            {
                disciplinas[i] = new Disciplina(-1);
            }
        }

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            disciplinas = new Disciplina[12];
            for (int i = 0; i < 12; i++)
            {
                disciplinas[i] = new Disciplina(-1);
            }
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            bool podeAdd;
            int aux = 0;

            while (Disciplinas[aux].Id != -1 && aux < 12)
            {
                aux++;
            }

            podeAdd = (aux < 12);

            if (podeAdd)
            {
                Disciplinas[aux] = disciplina; 
            }

            return podeAdd;
        }

        public Disciplina PesquisarDisciplina(Disciplina disciplina)
        {
            Disciplina disciplinaPesquisada = new Disciplina(-1);

            foreach (Disciplina d in Disciplinas)
            {
                if (d.Id.Equals(disciplina.Id))
                {
                    disciplinaPesquisada = d;
                }
            }

            return disciplinaPesquisada;
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            bool podeRemover;
            int aux = 0;

            int kAluno = 0;
            foreach (Aluno aluno in disciplina.Alunos)
            {
                for(int i = 0; i < 15; i++)
                {
                    if (aluno.Id != -1)
                    {
                        kAluno++;
                        break;
                    }
                }
            }


            while (Disciplinas[aux].Id != disciplina.Id && aux < 12 - 1)
            {
                aux++;
            }

            podeRemover = (aux < 12 && kAluno == 0);

            if (podeRemover)
            {
                while (aux < 12 - 1)
                {
                    Disciplinas[aux] = Disciplinas[aux + 1];
                    aux++;
                }
                Disciplinas[aux] = new Disciplina(-1);
            }

            return podeRemover;

        }
    }
}
