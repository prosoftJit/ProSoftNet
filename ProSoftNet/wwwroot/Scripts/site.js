/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// **** LEMBRE-SE DE USAR CTRL+F5 PARA RECARREGAR OS SCRIPTS EXTERNOS NO BROWSER QUANDO HOUVER ALGUMA MODIFICAÇÃO
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// pega sugestões para o autocomplete

var reais_inputmask = undefined;

function GetSuggestions(param, done, id) {
    var data = { term: param, 'id': id };
    $.ajax({
        type: "POST",
        url: '/Empenho/CredorAutocomplete',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (ret, status, jqxhr) {
            if (status == 'success' && ret != null && ret != undefined) {
                done(ret);
            }
        },
        error: function (xhr, status, errorThrown) {
            alert(xhr.responseText);
        }
    });
}

// liga o autocomplete para que sejam encontrados credores
function BindAutocomplete($selector, $hidden) {
    if ($selector == undefined || $selector == null) {
        $selector = $('#campo-busca');
    }

    $selector.on('change', function (event) {
        if (this.value == '' || this.value == undefined) {
            $hidden.val('');
        }
    });

    if ($hidden == undefined || $hidden == null) {
        $hidden = $selector.next();
    }
    $selector.devbridgeAutocomplete({
        lookup: GetSuggestions,
        minChars: 5,
        dataType: 'jsonp',
        onSearchError: function (query, jqXHR, textStatus, errorThrown) {
            alert(query + "\n" + textStatus + "\n" + errorThrown + "\n" + jqXHR.responseText);
        },
        onSelect: function (suggestion) {
            $hidden.val(suggestion.data);
        },
        onInvalidateSelection: function () {
            $hidden.val('');
        }
    });

    var id = $hidden.val();
    GetSuggestions(null, function (ret) {
        if (ret.suggestions.length > 0)
            $selector.val(ret.suggestions[0].value);
    }, id);
};

// aplica uma mascara de data
function mascaraData(controle) {
    var pass = controle.value;
    var expr = /[0123456789]/;

    for (i = 0; i < pass.length; i++) {
        // charAt -> retorna o caractere posicionado no índice especificado
        var lchar = val.value.charAt(i);
        var nchar = val.value.charAt(i + 1);

        if (i == 0) {
            // search -> retorna um valor inteiro, indicando a posição do inicio da primeira
            // ocorrência de expReg dentro de instStr. Se nenhuma ocorrencia for encontrada o método retornara -1
            // instStr.search(expReg);
            if ((lchar.search(expr) != 0) || (lchar > 3)) {
                val.value = "";
            }

        } else if (i == 1) {

            if (lchar.search(expr) != 0) {
                // substring(indice1,indice2)
                // indice1, indice2 -> será usado para delimitar a string
                var tst1 = val.value.substring(0, (i));
                val.value = tst1;
                continue;
            }

            if ((nchar != '/') && (nchar != '')) {
                var tst1 = val.value.substring(0, (i) + 1);

                if (nchar.search(expr) != 0)
                    var tst2 = val.value.substring(i + 2, pass.length);
                else
                    var tst2 = val.value.substring(i + 1, pass.length);

                val.value = tst1 + '/' + tst2;
            }

        } else if (i == 4) {

            if (lchar.search(expr) != 0) {
                var tst1 = val.value.substring(0, (i));
                val.value = tst1;
                continue;
            }

            if ((nchar != '/') && (nchar != '')) {
                var tst1 = val.value.substring(0, (i) + 1);

                if (nchar.search(expr) != 0)
                    var tst2 = val.value.substring(i + 2, pass.length);
                else
                    var tst2 = val.value.substring(i + 1, pass.length);

                val.value = tst1 + '/' + tst2;
            }
        }

        if (i >= 6) {
            if (lchar.search(expr) != 0) {
                var tst1 = val.value.substring(0, (i));
                val.value = tst1;
            }
        }
    }

    if (pass.length > 10)
        val.value = val.value.substring(0, 10);
    return true;
}

// converte um texto em número, substituindo a vírgula por ponto
// retorna 0 em caso de erro
String.prototype.toNumber = function () {
    var txt = this.replace(/\./g, '').replace(',', '.');
    var v = parseFloat(txt);
    if (isNaN(v))
        v = 0;
    return v;
}

// converte um número em texto formatado, com duas casas depois da vírgula
Number.prototype.toValueStr = function (decimals = 2) {
    //if (decimals == undefined || decimals == null)
    //    decimals == 2;
    return this.toFixed(decimals).replace('.', ',');// .toLocaleString('pt-BR', { minimumFractionDigits: 2 });
}

// cria a função "format" nos strings
// substitui ocorrências de {0}, {1}, {2}... pelo valor dos parâmetros passados
// exemplo: '<li>{0}</li>'.format('Teste') - resultado: <ul>Teste</ul>
String.prototype.format = function(){
	var v = this;
	for (i in arguments) {
		v = v.replace('{'+i+'}', arguments[i]);
	}
	return v;
}
// converte uma data em formato string para formato date
String.prototype.toDate = function () {
    if (this != null && this.length >= 10) {
        var parts = this.substring(0, 10).split("/");
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }
    else
        return null;
}
// retorna uma data em formato string
Date.prototype.toDMYString = function () {
	return ("0" + this.getDate()).slice(-2) + "/" + ("0" + (this.getMonth() + 1)).slice(-2) + "/" + this.getFullYear();
}
// retorna uma data no formado yyyy-mm-dd
Date.prototype.toYMDString = function () {
    return this.getFullYear() + '-' + ('0' + (this.getMonth() + 1)).slice(-2) + '-' + ('0' + this.getDate()).slice(-2); 
}
/// Inverte dia e mês em uma data
Date.prototype.invertDayMonth = function () {
	return new Date(this.getFullYear(), this.getDate()-1, this.getMonth()+1, this.getHours(), this.getMinutes(), this.getSeconds());
}

Date.prototype.diffMonths = function (d2) {
    var months;
    months = (d2.getFullYear() - this.getFullYear()) * 12;
    months -= this.getMonth();
    months += d2.getMonth();
    return months <= 0 || Number.isNaN(months) ? 0 : months;
}

Date.prototype.datePattern = function () {
    return "^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
}



// retorna medidas para ajustar um retângulo dentro de outro (ou uma foto em um div)
// de maneira que ocupe o espaço máximo, sem cortar a foto
function getAdujstedSize(containerSize, contentStartingSize) {

    var wid = contentStartingSize.width;
    var hei = contentStartingSize.height;
    var difwid = containerSize.width / wid;
    var difhei = containerSize.height / hei;

    var scale;
    if (difwid < difhei) {
        scale = difwid;
    } else {
        scale = difhei;
    }

    wid *= scale;
    hei *= scale;

    var elleft = ((containerSize.width - wid) / 2);
    var eltop = ((containerSize.height - hei) / 2);

    return {
        left: elleft,
        top: eltop,
        width: wid,
        height: hei,
        scale: scale
    };
}
// ajusta o tamanho de uma foto dentro de um retângulo
function adjustElementInsideRectangle(rectWidth, rectHeight, element) {

    var rect = getAdujstedSize({ width: rectWidth, height: rectHeight }, {width: element.width(), height: element.height()});

    element.css({
        position: 'absolute',
        left: rect.left,
        top: rect.top,
        width: rect.width,
        height: rect.height
    });
}
// ajusta uma foto dentro de uma div
function adjustElementOnDiv(div, element) {

    div.css({
        position: 'relative'
    });

    adjustElementInsideRectangle(div.width(), div.height(), element);
}


function ajax(URL, data, updateDOMobject) {
    ajax(url, data, function (ret) {
        updateDOMobject.innerHTML = ret;
    }, function (xhr, status, error) {
        alert(xhr.errorMessage);
    });
}

function load2(URL, loadDOMElement, formElement, onSuccess, onError) {
    let formData = null;
    if (formElement != undefined)
        formData = new FormData(formElement);

    fetch(URL, { method: "POST", body: formData })
        .then(function (response) {
            return response.text();
        })
        .then(function (html) {
            loadDOMElement.outerHTML = html;
            if (onSuccess != undefined)
                onSuccess();
        })
        .catch(function (err) {
            if (onError != undefined)
                onError(err);
        });
}
function load(URL, loadDOMElementId, formId, onSuccess, onError) {

    let formData = null;
    if (formId != undefined)
        formData = new FormData(document.getElementById(formId));

    fetch(URL, { method: "POST", body: formData })
        .then(function (response) {
            return response.text();
        })
        .then(function (html) {
            document.getElementById(loadDOMElementId).outerHTML = html;
            if (onSuccess != undefined)
                onSuccess();
        })
        .catch(function (err) {
            if (onError != undefined)
                onError(err);
        });
}

// retorna o parâmetro 'row_id' da linha <tr> que contêm as classes 'selectable-row active'
// esse parâmetro geralmente é o id do registro da linha
function selectedTrId() {
    var sel = document.getElementsByClassName('selectable-row active');

    if (sel.length > 0)
        return sel[0].getAttribute('row_id');

    return -1;
}

function showLoad() {
    var div = document.createElement('div');
    div.style = "position:fixed; display:block; top: 0; left: 0; right: 0; bottom: 0; background-color: white; z-index: 1000; opacity: 0.5";
    document.body.appendChild(div);
}
function hideLoad() {
}

// **** LEMBRE-SE DE USAR CTRL+F5 PARA RECARREGAR OS SCRIPTS EXTERNOS NO BROWSER QUANDO HOUVER ALGUMA MODIFICAÇÃO
// essa função define onclick em todos os componentes que tem data-bs-toggle="load"
// dessa forma, quando esse componente for clicado, a URL descrita em href será executada (acão em um controller)
// e o conteúdo do div descrito por data-bs-target será substituido pelo conteúdo retornado pela view da ação
// <button type="button" href="/Empenho/Conta_Delete?idCompraCredor=255" data-bs-target="#itemsContainer" data-bs-toggle="load" >Excluir</button>
$(function () {

    jQuery(document).ready(function () {

        hideLoad();

        // defaults para o datepicker
        $.fn.datepicker.defaults.format = "yy-mm-dd";
        $.fn.datepicker.defaults.language = "pt-BR";
        $.fn.datepicker.defaults.autoclose = true;

        Inputmask.extendAliases({
            reais: {
                alias: "currency",
                autoUnmask: true,
                radixPoint: ",",
                groupSeparator: ".",
                allowMinus: true,
                prefix: "R$ ",
                digits: 2,
                digitsOptional: false,
                rightAlign: true,
                unmaskAsNumber: true,
                removeMaskOnSubmit: true
            }
        });

        $('.moedaReal').inputmask('decimal', {
            radixPoint: ",",
            groupSeparator: ".",
            autoGroup: true,
            digits: 2,
            digitsOptional: false,
            placeholder: '0',
            rightAlign: false,
            prefix: "R$ ",
            allowMinus: true,
            unmaskAsNumber: true,
            removeMaskOnSubmit: true,
        });

        Inputmask.extendDefaults({
            'autoUnmask': true,
            'removeMaskOnSubmit': true
        });

        reais_inputmask = new Inputmask('reais');


        $('.datepicker').datepicker(
            {

                dateFormat: 'yy-mm-dd',
                onSelected: function (dateText, inst) {
                    alert(dateText);
                    $(inst).val(dateText); // Write the value in the input
                }
            }

        );
        $('.datepicker').on('dateSelected', function (dateText, inst) {
                    alert(dateText);
                    $(inst).val(dateText); // Write the value in the input
                }
        );


        var loadingCallStack = 0;
        $(document).bind("ajaxSend", function () {
            loadingCallStack++;
            $("#ajaxLoadingModal").show();
        }).bind("ajaxComplete", function () {
            loadingCallStack--;
            if (loadingCallStack <= 0) {
                $("#ajaxLoadingModal").hide();
                loadingCallStack = 0;
            }
        });

        // acrescenta a classe 'active' na linha (<tr>) clicada e retira de todas as outras
        $('.selectable-row').on('click', function (event) {
            event.preventDefault();

            if ($(this).hasClass('active')) {
                $(this).removeClass('active');
            } else {
                $(this).addClass('active').siblings().removeClass('active');
            }
        });
        
        // aciona todos os tooltips
        $(function () {
            $("[rel='tooltip']").tooltip();
        });

        // um autolink é um <TR> que contém um atributo row_id="123", um target="_blank" ou [data-bs-toggle="modal e data-bs-target="#idDoModal"]
        // onde row_id é o id do objeto
        // target indica se a resposta deve abrir em uma nova página ou na mesma (caso não seja modal)
        // data-bs-toggle indica que a resposta deve abrir numa modal e data-bs-target é o id da modal
        $('.autolink').on('click', function (e) {
            e.preventDefault();

            // de agora em diante, href deve conter o link completo
            var href = $(this).attr('href');//.format(selectedTrId());

            var link = this;

            // is this link a modal toggler? if yes, call href as ajax
            if (this.getAttribute('data-bs-toggle') == 'modal') {
                $.ajax({
                    url: href,
                    success: function (data) { // replace modal-content content
                        $(link.getAttribute('data-bs-target') + ' .modal-content').html(data);
                    }
                });
            } else if (this.target == "_blank") // if target is _blank, open new window
                window.open(href);
            else
                location.href = href;

            return true;
        });

        // <a href="/controller/action?id=123" data-bs-toggle="load" data-bs-target="#elemento">Carregar dados</a>
        // se um link ou botão for marcado com data-bs-toggle="load", href e data-bs-target, onde
        // data-bs-toggle="load" indica que um conteúdo (resposta de ajax.load) deve ser carregado no target
        // href - /controller/ação a ser chamada por ajax
        // data-bs-target - o id de um elemento, com "#" na frente, onde o conteúdo deverá ser carregado
        $('*[data-bs-toggle="load"]').click(function (e) {
            e.preventDefault();

            var url = $(this).attr('href');

            var dtarget = $(this).attr('data-bs-target');

            $(dtarget).load(url);

            return false;
        });

        function loadModalContent(sender) {
            let href = sender.getAttribute('href');
            var target = sender.getAttribute('data-bs-target');
            ajax(href, {}, function (ret) {
                $(target + " .modal-content").html(ret);
            }, function (xhr) {
                alert(xhr.responseText);
            });
        }
        $('button[data-bs-toggle="modal"][href]').click(function () {
            loadModalContent(this);
        });
        $('a[data-bs-toggle="modal"][href]').click(function () {
            loadModalContent(this);
        });

        // inputs com o atributo format_digits=? onde ? é um número terão o valor formatado com ? zeros depois da vírgula
        function format_digits(input) {
            var d = $(input).attr('format_digits');
            if (d == '' || isNaN(d))
                d = '2';
            var digits = d.toNumber();
            $(input).val($(input).val().toNumber().toValueStr(digits));
        }
        $('*[format_digits]').on('blur', function () {
            format_digits(this);
        });
        $('*[format_digits]').each(function () {
            format_digits(this);
        });

        // limpa um modal após fechar
        $(".modal").on("hidden.bs.modal", function () {
            $(this).removeData();
        });

        // any button with href attribute calls href (except those with data-bs-toggle="modal" that is already called by default)
        $('button[href]').not('[data-bs-toggle=modal]').click(function () {
            var href = this.getAttribute('href');
            if (this.getAttribute('target') == '_blank')
                window.open(href);
            else
                location.href = href;
        });

        // marca-se a linha <tr> de uma tabela com a classe "clickable-row" e adiciona-se href com o destino do clique
        //	<tr class="clickable-row" href="/Empenho/Processo_Edit?idProcesso=@item.IdProcesso">
        $(".clickable-row").click(function () {
            var href = $(this).attr("href");
            location.href = $(this).attr("href");
        });

        // um elemento marcado com o atributo 'confirm' e seu valor com uma mensagem de confirmação, exibirão um diálogo de confirmação quando clicado
        Array.from($('*[confirm]')).forEach(function (item) {
            item.onclick = function (e) {
                return confirm(this.getAttribute('confirm'));
            };
        });

        // permite que uma <tr> marcada com a classe clickable-row-modal carregue um modal automaticamente quando tiver os atributos
        // data-bs-target indica o modal id target dos dados
        // href contem o href do /controller/ação a ser chamado
        $(".clickable-row-modal").click(function () {
            var modalId = $(this).attr("data-bs-target");
            var href = $(this).attr("href");

            $(modalId + ' .modal-content').innerHTML = '';

            $(modalId + ' .modal-content').load(href);

            const myModal = new bootstrap.Modal(modalId);
            myModal.show();
            //$(modalId).modal();
        });
    });

    // focus first input on modal that have a autofocus attribute
    $('.modal').on('shown.bs.modal', function () {
        $(this).find('[autofocus]').focus();
        $(this).find('[autofocus]').select();
    });

})


// posta dados em ajax (data em json)
function ajax(url, data, onsuccess, onerror, _sync) {

    var aj_type = 'POST';
    if (url.startsWith('GET:')) {
        url = url.substring(4);
        aj_type = 'GET';
    }

    if (onerror == undefined || onerror == null) {
        onerror = function (xhr, status, error) {
            alert(xhr.responseText)
        };
    }

	if (_sync == null || _sync == undefined) {
		_sync = false;
    }
    
    var _dt = data;

    if (typeof(_dt) === 'object')
        _dt = JSON.stringify(data);

    $.ajax({
        type: aj_type,
        url: url,
        contentType: 'application/json; charset=utf-8',
//        dataType: "json",
        data: _dt,
		async: !_sync,
        success: function (msg) {
            onsuccess(msg);// jQuery.parseJSON(msg) );
        },
        error: function (xhr, status, error) {
            onerror(xhr, status, error);
        }
    });
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    let name = cname + "=";
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function checkCookie(cname) {
    return getCookie(cname) != "";
}