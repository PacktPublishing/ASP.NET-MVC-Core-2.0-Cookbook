define(function () {
    var list = [];
    return {
        add: function (item) {
            list.push(item);
        },
        renderList: function() {
            var html = '';

            for (var iLoop = 0, len = list.length; iLoop < len; iLoop++){
                html += '<li class="list-group-item">' + list[iLoop] + '</li>';
            }

            return html;
        }
    };
});