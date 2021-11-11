const Disciplinas = {

    state: [],
    getAll() {
        $.get('http://localhost:5000/disciplina/listar')
            .done(function (resposta) {
                for (let index = 0; index < resposta.length; index++) {
                    const element = resposta[index];
                    $('#id_diciplina').append($(Disciplinas.checkbox(element)));
                }
            })
            .fail(function (erro, mensagem, excecao) {
                alert(mensagem + ': ' + excecao);
            });
    },

    checkbox({codDisciplina,nome}) {
        return `
            <div class="form-check">
            <input class="form-check-input" name="disciplinas" type="checkbox" value="${codDisciplina}" id="dsc_${codDisciplina}">
                <label class="form-check-label" for="dsc_${codDisciplina}">
                ${nome}
                </label>
            </div>
        `;
    }
};