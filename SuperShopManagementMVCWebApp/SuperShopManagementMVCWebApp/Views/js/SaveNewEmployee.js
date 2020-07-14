<script type="text/javascript">
    $(function () {
        $('#birthdate').datetimepicker({
            format: "DD/MM/YYYY"
        }).on('dp.change', function (e) {

            $(this).data('DateTimePicker').hide();
        })

});

</script>