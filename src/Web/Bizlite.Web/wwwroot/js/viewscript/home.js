(function ($) {

    function HomeIndex() {
        var $this = this;
        function initializePage() {
            formAddEditPresenter = new Global.FormHelper($("#frmlogin"),
                {
                    updateTargetId: "validation-summary", beforeSubmit: function () {
                      
                        return true;
                    }
                }, function onSuccess(result) {
                    if (result.errorMessage) {
                        alertify.error(result.errorMessage)
                    }
                    else {
                        window.location.href = result.redirectUrl;
                    }
                });

        }
       
        $this.init = function () {
            initializePage();
           

        };
    }
    $(function () {
        var self = new HomeIndex();
        self.init();
    });

}(jQuery));

