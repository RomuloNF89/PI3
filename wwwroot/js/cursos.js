const Cursos = {
    state: [],
    getAll() {
        $.get('http://localhost:5000/curso/listar')
            .done(function (resposta) {
                for (let index = 0; index < resposta.length; index++) {
                    const element = resposta[index];
                    $('#id_curso').append($('<option></option>').val(element.codCurso).html(element.nome));
                }
            })
            .fail(function (erro, mensagem, excecao) {
                alert(mensagem + ': ' + excecao);
            });
    },
}