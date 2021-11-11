

const Estudante = {

    selectors: {
        nome: $('#id_nome'),
        idade: $('#id_idade'),
        data: $('#id_data'),
        curso: $('#id_curso'),
        telefone: $('#id_tel'),
        email: $('#id_email'),
        endereco: $('#id_endereco'),
        graduado: $('#id_graduado'),
        id: $('#id_matEstudante'),
    },
    salvar(event) {
        event.preventDefault();
        const form = $('#formulario_estudante')[0];

        const { nome, idade, id, data, curso, telefone, email, endereco, graduado } = this.selectors;
        //const checked = Array.from(document.querySelectorAll("input[type=checkbox][name=disciplinas]:checked")).map(e => e.value);
        const payload = {
            nome: nome.val(),
            idade: idade.val(),
            codCurso: curso.val(),
            telefone: telefone.val(),
            email: email.val(),
            endereco: endereco.val(),
            matEstudante: parseInt(id.val()),
            graduado: graduado.is(':checked'),
            respFinanceiro: false
            //  disciplinas: checked
        }

        const url = payload.matEstudante === 0 ? 'http://localhost:5000/estudante/store' : 'http://localhost:5000/estudante/update';
        if (formValidate(event, form))
            fetch(url,
                {
                    method: payload.matEstudante === 0 ? "POST" : "PUT",
                    body: JSON.stringify(payload),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(async res => await res.json())
                .then(json => {
                    this.renderTable([json])
                })
                .then(() => form.reset())
                .catch(error => console.log(error));
    },
    renderTable(response) {

        for (i = 0; i < response.length; i++) {
            let dados = response[i];
            $('#grid').find(`#${dados.matEstudante}`).remove();

            $('#grid').append($('<tr></tr>').attr('id', dados.matEstudante).attr('data-src', JSON.stringify(dados))
                .append($('<td></td>').html(dados.nome))
                .append($('<td></td>').html(dados.idade))
                .append($('<td></td>').html(dados.email))
                .append($('<td></td>').html(dados.codCursoNavigation.nome))
                .append($('<td></td>').html(dados.graduado ? 'Sim' : 'Não'))
                .append($('<td></td>').html(`<a href="#" onclick="Estudante.edit(event)"> <span class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></span></a>`))
                .append($('<td></td>').html(`<a href="#" onclick="Estudante.apagar(event)"><span class="fa fa-trash-o fa-lg text-danger" aria-hidden="true"></span></a>`))
            );
        }
    },
    renderTableInative(response) {

        if (response.length === 0) {
            $('#grid_inativo').html('<tr><td> Não existem dados!</td></tr>');
            return null;
        }
        for (i = 0; i < response.length; i++) {
            let dados = response[i];
            $('#grid_inativo').find(`#${dados.matEstudante}`).remove();

            $('#grid_inativo').append($('<tr></tr>').attr('id', dados.matEstudante).attr('data-src', JSON.stringify(dados))
                .append($('<td></td>').html(dados.nome))
                .append($('<td></td>').html(dados.idade))
                .append($('<td></td>').html(dados.email))
                .append($('<td></td>').html(dados.codCursoNavigation.nome))
                .append($('<td></td>').html(dados.graduado ? 'Sim' : 'Não'))
                .append($('<td></td>').html(dados.deleted))
                .append($('<td></td>').html(`<a href="#" onclick="Estudante.restore(event)"> <span class="fa fa-back fa-lg" aria-hidden="true"></span></a>`))
            );
        }
    },
    listarGrid() {
        $.get('http://localhost:5000/estudante/listar')
            .done(function (resposta) {
                Estudante.renderTable(resposta);
            })
            .fail(function (erro, mensagem, excecao) {
                alert(mensagem + ': ' + excecao);
            });
    },
    listarGridInativos() {
        $.get('http://localhost:5000/estudante/listarInativos')
            .done(function (resposta) {
                Estudante.renderTableInative(resposta);
            })
            .fail(function (erro, mensagem, excecao) {
                alert(mensagem + ': ' + excecao);
            });
    },
    edit(event) {
        const { nome, idade, id, curso, telefone, email, endereco, graduado } = this.selectors;
        const data_edit = $(event.target).closest('tr').data('src');

        nome.val(data_edit.nome);
        id.val(data_edit.matEstudante);
        idade.val(data_edit.idade);
        telefone.val(data_edit.telefone);
        email.val(data_edit.email);
        endereco.val(data_edit.endereco);
        graduado.attr('checked', data_edit.graduado);
        curso.val(data_edit.codCursoNavigation.codCurso);

    },
    apagar(event) {
        const { matEstudante } = $(event.target).closest('tr').data('src');

        if (confirm(`Deseja Realment Excluir o registro [${matEstudante}]?`))
            fetch('http://localhost:5000/estudante/delete',
                {
                    method: "DELETE",
                    body: JSON.stringify(matEstudante),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(async (res) => await res.text())
                .then(text => {
                    $(event.target).closest('tr').remove();
                })
                .catch(error => console.log(error));
    },
    apagarLogic(event) {
        const { matEstudante } = $(event.target).closest('tr').data('src');

        if (confirm(`Deseja Realment Excluir o registro [${matEstudante}]?`))
            fetch('http://localhost:5000/estudante/deleteLogic',
                {
                    method: "DELETE",
                    body: JSON.stringify(matEstudante),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(async (res) => await res.text())
                .then(text => {
                    $(event.target).closest('tr').remove();
                })
                .catch(error => console.log(error));
    },

    run() {
        const form = $('#formulario_estudante')[0];

        this.listarGrid();
        //Dependencias
        Cursos.getAll();
        Disciplinas.getAll();
        //Listener
        form.addEventListener('reset', () => {
            this.selectors.id.val(0);
        });
        const tabEl2 = document.getElementById('_deleted-tab');
        //const tabEl1 = document.getElementById('_actived-tab');

        tabEl2.addEventListener('shown.bs.tab', function (event) {
            Estudante.listarGridInativos();
        });
    }

}
