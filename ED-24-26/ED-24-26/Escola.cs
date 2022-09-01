using System;
using System.Collections.Generic;
using System.Text;

namespace ED_24_26
{
    class Escola
    {
        private Curso[] cursos;

        internal Curso[] Cursos { get => cursos; set => cursos = value; }

        public Escola()
        {
            cursos = new Curso[5];
            for (int i = 0; i < cursos.Length; i++)
            {
                cursos[i] = new Curso(-1);
            }
        }


        public bool AdicionarCurso(Curso curso)
        {
            bool podeAdd;
            int aux = 0;

            while (Cursos[aux].Id != -1 && aux < 5)
            {
                aux++;
            }

            podeAdd = (aux < 5);

            if (podeAdd)
            {
                Cursos[aux] = curso; 
            }

            return podeAdd;
        }

        public Curso PesquisarCurso(Curso curso)
        {
            Curso cursoPesquisado = new Curso(-1);

            foreach (Curso c in cursos)
            {
                if (c.Id.Equals(curso.Id))
                {
                    cursoPesquisado = c;
                }
            }

            return cursoPesquisado;
        }

        public bool RemoverCurso(Curso curso)
        {
            bool podeRemover;
            int aux = 0;

            foreach (Disciplina disciplina in curso.Disciplinas)
            {
                if (disciplina.Id != -1)
                {
                    podeRemover = false;
                    return podeRemover;
                }
            }

            while (cursos[aux].Id != curso.Id && aux < 5-1)
            {
                aux++;
            }

            podeRemover = (aux < 5);

            if (podeRemover)
            {
                while (aux < 5 - 1)
                {
                    Cursos[aux] = Cursos[aux + 1];
                    aux++;
                }
                cursos[aux] = new Curso(-1); 
            }

            return podeRemover;

        }
    }
}
