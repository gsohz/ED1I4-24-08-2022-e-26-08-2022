internal class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Aluno[] Alunos { get => alunos; set => alunos = value; }


        public Disciplina(int id)
        {
            Id = id;
            Alunos = new Aluno[15];
            /*
            for (int i = 0; i < alunos.Length; i++)
            {
                alunos[i] = new Aluno();
            */
        }
        
        public Disciplina(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Alunos = new Aluno[15];
        }

        public bool MatricularAluno(Aluno aluno)
        {
          bool podeAdd;
            int aux = 0;

            while (Alunos[aux].Id != -1 && aux < 15)
            {
                aux++;
            }

            podeAdd = (aux < 15);

            if (podeAdd)
            {
                Alunos[aux] = aluno; //isso pode dar errado -> new Curso()
            }

            return podeAdd;
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
          bool podeRemover;
            int aux = 0;

            while(Alunos[aux].Id != -1 && aux < 15)
            {
                aux++;
            }
            
            podeRemover = (aux < 15);

            if (podeRemover)
            {
                while (aux < 15 - 1)
                {
                    Alunos[aux] = Alunos[aux + 1];
                    aux++;
                }
                Alunos[aux] = new Aluno(-1, "...."); //pode dar errado add "..."
            }

            return podeRemover;
        }
    }