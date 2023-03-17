using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicativoDeNotas
{
    public partial class FormNotas : Form
    {
        // Crie uma lista para armazenar as notas e suas tarefas
        List<Nota> notas = new List<Nota>();

        public FormNotas()
        {
            InitializeComponent();
        }

        // Método para adicionar uma nova nota à lista
        private void AdicionarNota()
        {
            string titulo = textBoxTituloNota.Text;
            Nota nota = new Nota(titulo);
            notas.Add(nota);
            AtualizarListaNotas();
            textBoxTituloNota.Text = "";
        }

        // Método para atualizar a lista de notas e suas tarefas
        private void AtualizarListaNotas()
        {
            listBoxNotas.Items.Clear();
            foreach (Nota nota in notas)
            {
                listBoxNotas.Items.Add(nota.Titulo);
            }
        }

        // Evento de clique do botão Adicionar Nota
        private void buttonAdicionarNota_Click(object sender, EventArgs e)
        {
            AdicionarNota();
        }

        // Evento de clique do botão Adicionar Tarefa
        private void buttonAdicionarTarefa_Click(object sender, EventArgs e)
        {
            if (listBoxNotas.SelectedIndex >= 0)
            {
                Nota nota = notas[listBoxNotas.SelectedIndex];
                string tarefa = textBoxTarefa.Text;
                nota.AdicionarTarefa(tarefa);
                AtualizarListaTarefas(nota);
                textBoxTarefa.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma nota para adicionar a tarefa.");
            }
        }

        // Método para atualizar a lista de tarefas de uma nota
        private void AtualizarListaTarefas(Nota nota)
        {
            listBoxTarefas.Items.Clear();
            foreach (Tarefa tarefa in nota.Tarefas)
            {
                listBoxTarefas.Items.Add(tarefa.Texto + (tarefa.Concluida ? " (Concluída)" : ""));
            }
        }

        // Evento de clique do botão Concluir Tarefa
        private void buttonConcluirTarefa_Click(object sender, EventArgs e)
        {
            if (listBoxNotas.SelectedIndex >= 0 && listBoxTarefas.SelectedIndex >= 0)
            {
                Nota nota = notas[listBoxNotas.SelectedIndex];
                Tarefa tarefa = nota.Tarefas[listBoxTarefas.SelectedIndex];
                tarefa.Concluida = !tarefa.Concluida;
                AtualizarListaTarefas(nota);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma nota e uma tarefa para concluir.");
            }
        }

        // Evento de seleção de uma nota na lista de notas
        private void listBoxNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNotas.SelectedIndex >= 0)
            {
                Nota nota = notas[listBoxNotas.SelectedIndex];
                labelTituloNota.Text = nota.Titulo;
                AtualizarListaTarefas(nota);
            }
            else
            {
                labelTituloNota.Text = "";
                listBoxTarefas.Items.Clear();
            }
        }
    }

   
