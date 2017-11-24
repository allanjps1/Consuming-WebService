
var botaoBuscar = $("#btn-buscar");

botaoBuscar.bind("click", function () {

    var table = $("#tblResultado tbody");

    var cidade = {
        Nome: $("#cidade").val(),
        Estado: $("#estado").val()
    }

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: `/Home/ObterCidadesPorNomeEEstado`,
        data: cidade,
        success: function (result) {

            table.html("");

            if (result.length > 0) {

                $(result).each(function (index, value) {

                    var html = "";
                    html += "<tr>";
                    html += "<td class='cidade-estado'>" + value.Estado + "</td>";
                    html += "<td class='cidade-nome'>" + value.Nome + "</td>";
                    html += "<td class='ver-pontuacao'> Ver Pontuação </td>";
                    html += "</tr>";

                    table.append(html);
                });

                bindClickPontuacao();
            }
            else {
                var htmlSemRegistros = "";

                htmlSemRegistros += "<tr>";
                htmlSemRegistros += '<td colspan="3" style="text-align: center">Não foram encontrados registros para os filtros utilizados</td>';
                htmlSemRegistros += "</tr>";

                table.append(htmlSemRegistros);
            }
        },
        error: function (result) {
            console.log("Ocorreu um erro!");
        }
    });
});

function bindClickPontuacao() {
    $(".ver-pontuacao").unbind("click");
    $(".ver-pontuacao").bind("click", function () {
        var estado = $(this).closest("tr").find(".cidade-estado").text();
        var nome = $(this).closest("tr").find(".cidade-nome").text();

        mostrarPontuacao(nome, estado);
    });
}

function mostrarPontuacao(nome, estado) {
    var cidade = {
        Nome: $("#cidade").val(),
        Estado: $("#estado").val()
    }

    console.log(cidade);

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: `/Home/ObterPontuacaoCidade`,
        data: cidade,
        success: function (result) {
            console.log("dentro do sucess");
            console.log(result);

            alert("A pontuação da Cidade " + nome + " é " + result);
        },
        error: function (result) {
            console.log("Ocorreu um erro!");
        }
    });
}