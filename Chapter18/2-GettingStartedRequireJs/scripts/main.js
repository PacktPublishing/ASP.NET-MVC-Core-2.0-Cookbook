require.config({
    "baseUrl": "scripts",
    "paths": {
      "jquery": "https://code.jquery.com/jquery-3.2.1.min"
    }
});

require(['jquery', 'todo'], function($, todo) {
    $(document).ready(function() {
        $('button').click(function() {
            todo.add($('input').val());
            $('input').val('');
            $('input').focus();
            $('ul').html(todo.renderList());
        });
    });
});
