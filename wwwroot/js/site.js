$("#reply-form").submit(function (e) {
    e.preventDefault();
    var formValues = $(this).serializeArray();
    console.log(formValues);
    $.ajax({
        url: '/TaskItem/CreateReplyAjax',
        type: 'POST',
        data: (function () {
            var dataValues = {};
            formValues.forEach(function (formValue) {
                dataValues[formValue.name] = formValue.value;
            })
            return dataValues;
        })(),
        success: function (res) {
            var replies = $('#replies-container');
            $('#reply-form__content').val('');
            replies.closest('h3').remove();
            replies.append(
                `<div class="panel panel-default">
                    <div class="panel-body">
                        <div>${res.content}</div>
                        <div class="text-right">
                            ${res.userFirstName} ${res.userLastName}
                            <span> at ${res.dateCreated}</span>
                        </div>
                    </div>
                </div>`
            );

        },
        error: function (req, err) {
            console.log(err);
        }
    });
})