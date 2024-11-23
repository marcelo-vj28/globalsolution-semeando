// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Gerenciamento de páginas
// site.js
let idParaDeletar;
let tipoEntidade;
let idOpcao; // para o caso específico da tabela Opcao

function confirmarDelecao(id, tipo, idOpc = null) {
    idParaDeletar = id;
    tipoEntidade = tipo;
    idOpcao = idOpc;

    const modal = document.getElementById('deleteModal');
    modal.style.display = 'block';
}

function confirmarExclusao() {
    let url = `/Delecao/${tipoEntidade}/${idParaDeletar}`;

    // Caso especial para Opcao que tem chave composta
    if (tipoEntidade === 'Opcao' && idOpcao !== null) {
        url = `/Delecao/${tipoEntidade}/${idParaDeletar}/${idOpcao}`;
    }

    fetch(url, {
        method: 'DELETE',
    })
        .then(response => {
            if (response.ok) {
                window.location.reload();
            } else {
                alert('Erro ao deletar o registro');
            }
        })
        .catch(error => {
            console.error('Erro:', error);
            alert('Erro ao deletar o registro');
        });

    fecharModal();
}

function fecharModal() {
    const modal = document.getElementById('deleteModal');
    modal.style.display = 'none';
}
