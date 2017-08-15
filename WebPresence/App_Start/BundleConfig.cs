using System.Web;
using System.Web.Optimization;

namespace WebPresence
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // App Styles
            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Areas/Admin/Content/app/css/app.css",
                "~/Areas/Admin/Content/mvc-override.css"
            ));

            // Bootstrap Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                "~/Areas/Admin/Content/app/css/bootstrap.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/Angle").Include(
                // App init
                "~/Areas/Admin/Scripts/app/app.init.js",
                // Modules
                "~/Areas/Admin/Scripts/app/modules/bootstrap-start.js",
                "~/Areas/Admin/Scripts/app/modules/calendar.js",
                "~/Areas/Admin/Scripts/app/modules/classyloader.js",
                "~/Areas/Admin/Scripts/app/modules/clear-storage.js",
                "~/Areas/Admin/Scripts/app/modules/constants.js",
                "~/Areas/Admin/Scripts/app/modules/flatdoc.js",
                "~/Areas/Admin/Scripts/app/modules/trigger-resize.js",
                "~/Areas/Admin/Scripts/app/modules/fullscreen.js",
                "~/Areas/Admin/Scripts/app/modules/gmap.js",
                "~/Areas/Admin/Scripts/app/modules/load-css.js",
                "~/Areas/Admin/Scripts/app/modules/localize.js",
                "~/Areas/Admin/Scripts/app/modules/maps-vector.js",
                "~/Areas/Admin/Scripts/app/modules/navbar-search.js",
                "~/Areas/Admin/Scripts/app/modules/notify.js",
                "~/Areas/Admin/Scripts/app/modules/now.js",
                "~/Areas/Admin/Scripts/app/modules/panel-tools.js",
                "~/Areas/Admin/Scripts/app/modules/play-animation.js",
                "~/Areas/Admin//Scripts/app/modules/porlets.js",
                "~/Areas/Admin/Scripts/app/modules/sidebar.js",
                "~/Areas/Admin/Scripts/app/modules/skycons.js",
                "~/Areas/Admin/Scripts/app/modules/slimscroll.js",
                "~/Areas/Admin/Scripts/app/modules/sparkline.js",
                "~/Areas/Admin/Scripts/app/modules/table-checkall.js",
                "~/Areas/Admin/Scripts/app/modules/toggle-state.js",
                "~/Areas/Admin/Scripts/app/modules/utils.js",
                "~/Areas/Admin/Scripts/app/modules/chart.js",
                "~/Areas/Admin/Scripts/app/modules/morris.js",
                "~/Areas/Admin/Scripts/app/modules/rickshaw.js",
                "~/Areas/Admin/Scripts/app/modules/chartist.js",
                "~/Areas/Admin/Scripts/app/modules/tour.js",
                "~/Areas/Admin/Scripts/app/modules/sweetalert.js",
                "~/Areas/Admin/Scripts/app/modules/color-picker.js",
                "~/Areas/Admin/Scripts/app/modules/imagecrop.js",
                "~/Areas/Admin/Scripts/app/modules/chart-knob.js",
                "~/Areas/Admin/Scripts/app/modules/chart-easypie.js",
                "~/Areas/Admin/Scripts/app/modules/select2.js"
            ));

            // Main Vendor
            bundles.Add(new ScriptBundle("~/bundles/admin/jquery").Include(
                        "~/Scripts/jquery-3.1.1.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
            ));

            // Vendor Plugins

            bundles.Add(new ScriptBundle("~/bundles/matchMedia").Include(
                    "~/Areas/Admin/Vendor/matchMedia/matchMedia.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/sparklines").Include(
                "~/Areas/Admin/Vendor/sparkline/index.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/ChartJS").Include(
                 "~/Areas/Admin/Vendor/Chart.js/Chart.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/simpleLineIcons").Include(
              "~/Areas/Admin/Vendor/simple-line-icons/css/simple-line-icons.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/storage").Include(
              "~/Areas/Admin/Vendor/jQuery-Storage-API/jquery.storageapi.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEasing").Include(
              "~/Areas/Admin/Vendor/jquery.easing/js/jquery.easing.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
              "~/Areas/Admin/Vendor/datatables/media/js/jquery.dataTables.min.js",
              "~/Vendor/datatables-colvis/js/dataTables.colVis.js",
              "~/Areas/Admin/Vendor/datatables/media/js/dataTables.bootstrap.js",
              // Buttons
              "~/Areas/Admin/Vendor/datatables-buttons/js/dataTables.buttons.js",
              //"~/Vendor/datatables-buttons/css/buttons.bootstrap.css",
              "~/Areas/Admin/Vendor/datatables-buttons/js/buttons.bootstrap.js",
              "~/Areas/Admin/Vendor/datatables-buttons/js/buttons.colVis.js",
              "~/Areas/Admin/Vendor/datatables-buttons/js/buttons.flash.js",
              "~/Areas/Admin/Vendor/datatables-buttons/js/buttons.html5.js",
              "~/Areas/Admin/Vendor/datatables-buttons/js/buttons.print.js",
              "~/Areas/Admin/Vendor/datatables-responsive/js/dataTables.responsive.js",
              "~/Areas/Admin/Vendor/datatables-responsive/js/responsive.bootstrap.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/datatablesCss")
              .Include("~/Vendor/datatables-colvis/css/dataTables.colVis.css", new CssRewriteUrlTransform())
              .Include("~/Vendor/datatables/media/css/dataTables.bootstrap.css", new CssRewriteUrlTransform())
              .Include("~/Vendor/dataTables.fontAwesome/index.css", new CssRewriteUrlTransform())
            );

            bundles.Add(new ScriptBundle("~/bundles/parsley").Include(
              "~/Vendor/parsleyjs/dist/parsley.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/filestyle").Include(
              "~/Vendor/bootstrap-filestyle/src/bootstrap-filestyle.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/tagsinput").Include(
              "~/Vendor/bootstrap-tagsinput/dist/bootstrap-tagsinput.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/tagsinputCss").Include(
              "~/Vendor/bootstrap-tagsinput/dist/bootstrap-tagsinput.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/gmap").Include(
              "~/Vendor/jQuery-gMap/jquery.gmap.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/weatherIcons").Include(
              "~/Vendor/weather-icons/css/weather-icons.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/weatherIconsWind").Include(
              "~/Vendor/weather-icons/css/weather-icons-wind.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/skycons").Include(
              "~/Vendor/skycons/skycons.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/whirl").Include(
              "~/Areas/Admin/Vendor/whirl/dist/whirl.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/classyloader").Include(
              "~/Vendor/jquery-classyloader/js/jquery.classyloader.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/animo").Include(
              "~/Areas/Admin/Vendor/animo.js/animo.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/fastclick").Include(
              "~/Vendor/fastclick/lib/fastclick.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
              "~/Areas/Admin/Vendor/fontawesome/css/font-awesome.min.css", new CssRewriteUrlTransform()
            ));


            bundles.Add(new ScriptBundle("~/bundles/sliderCtrl").Include(
              "~/Vendor/seiyria-bootstrap-slider/dist/bootstrap-slider.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/sliderCtrlCss").Include(
              "~/Vendor/seiyria-bootstrap-slider/dist/css/bootstrap-slider.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/wysiwyg").Include(
              "~/Vendor/bootstrap-wysiwyg/bootstrap-wysiwyg.js",
              "~/Vendor/bootstrap-wysiwyg/external/jquery.hotkeys.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
              "~/Vendor/slimscroll/jquery.slimscroll.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/screenfull").Include(
              "~/Areas/Admin/Vendor/screenfull/dist/screenfull.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jvectormap").Include(
              "~/Vendor/ika.jvectormap/jquery-jvectormap-1.2.2.min.js",
              "~/Vendor/ika.jvectormap/jquery-jvectormap-world-mill-en.js",
              "~/Vendor/ika.jvectormap/jquery-jvectormap-us-mill-en.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/jvectormapCss").Include(
              "~/Vendor/ika.jvectormap/jquery-jvectormap-1.2.2.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/flot").Include(
              "~/Vendor/flot/jquery.flot.js",
              "~/Vendor/flot.tooltip/js/jquery.flot.tooltip.min.js",
              "~/Vendor/flot/jquery.flot.resize.js",
              "~/Vendor/flot/jquery.flot.pie.js",
              "~/Vendor/flot/jquery.flot.time.js",
              "~/Vendor/flot/jquery.flot.categories.js",
              "~/Vendor/flot-spline/js/jquery.flot.spline.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUi").Include(
              "~/Vendor/jquery-ui/jquery-ui.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUiTouchPunch").Include(
              "~/Vendor/jqueryui-touch-punch/jquery.ui.touch-punch.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
              "~/Vendor/moment/min/moment-with-locales.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
              "~/Vendor/jquery.inputmask/dist/jquery.inputmask.bundle.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/flatdoc").Include(
              "~/Vendor/flatdoc/flatdoc.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
              "~/Vendor/chosen_v1.2.0/chosen.jquery.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/chosenCss").Include(
              "~/Vendor/chosen_v1.2.0/chosen.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
              "~/Vendor/fullcalendar/dist/fullcalendar.min.js",
              "~/Vendor/fullcalendar/dist/gcal.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/fullcalendarCss").Include(
              "~/Vendor/fullcalendar/dist/fullcalendar.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/animatecss").Include(
              "~/Areas/Admin/Vendor/animate.css/animate.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/localize").Include(
              "~/Areas/Admin/Vendor/jquery-localize-i18n/dist/jquery.localize.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/nestable").Include(
              "~/Vendor/nestable/jquery.nestable.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/sortable").Include(
              "~/Vendor/html.sortable/dist/html.sortable.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqGrid").Include(
              "~/Vendor/jqgrid/js/jquery.jqGrid.js",
              "~/Vendor/jqgrid/js/i18n/grid.locale-en.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/jqGridCss").Include(
                "~/Vendor/jqgrid/css/ui.jqgrid.css",
                "~/Vendor/jquery-ui/themes/smoothness/jquery-ui.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/fileUploadCss").Include(
                "~/Vendor/blueimp-file-upload/css/jquery.fileupload.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/fileUpload").Include(
                "~/Vendor/jquery-ui/ui/widget.js",
                "~/Vendor/blueimp-tmpl/js/tmpl.js",
                "~/Vendor/blueimp-load-image/js/load-image.all.min.js",
                "~/Vendor/blueimp-canvas-to-blob/js/canvas-to-blob.js",
                "~/Vendor/blueimp-file-upload/js/jquery.iframe-transport.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload-process.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload-image.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload-audio.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload-video.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload-validate.js",
                "~/Vendor/blueimp-file-upload/js/jquery.fileupload-ui.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/xEditableCss").Include(
                "~/Vendor/x-editable/dist/bootstrap3-editable/css/bootstrap-editable.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/xEditable").Include(
              "~/Vendor/x-editable/dist/bootstrap3-editable/js/bootstrap-editable.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryValidate").Include(
              "~/Vendor/jquery-validation/dist/jquery.validate.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquerySteps").Include(
              "~/Vendor/jquery.steps/build/jquery.steps.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/datetimePicker").Include(
              "~/Vendor/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/datetimePickerCss").Include(
                "~/Vendor/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/RickshawCss").Include(
                "~/Vendor/rickshaw/rickshaw.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Rickshaw").Include(
              "~/Vendor/d3/d3.min.js",
              "~/Vendor/rickshaw/rickshaw.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/ChartistCss").Include(
                "~/Vendor/chartist/dist/chartist.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Chartist").Include(
              "~/Vendor/chartist/dist/chartist.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/MorrisCss").Include(
                "~/Vendor/morris.js/morris.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Morris").Include(
              "~/Vendor/raphael/raphael.js",
              "~/Vendor/morris.js/morris.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/Spinkit").Include(
                "~/Vendor/spinkit/css/spinkit.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/LoadersCss").Include(
                "~/Vendor/loaders.css/loaders.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/JQCloud").Include(
              "~/Vendor/jqcloud2/dist/jqcloud.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/JQCloudCss").Include(
                "~/Vendor/jqcloud2/dist/jqcloud.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/SweetAlertCss").Include(
                "~/Vendor/sweetalert/dist/sweetalert.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/SweetAlert").Include(
                "~/Vendor/sweetalert/dist/sweetalert.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/BootstrapTourCss").Include(
                "~/Vendor/bootstrap-tour/build/css/bootstrap-tour-standalone.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/BootstrapTour").Include(
                "~/Vendor/bootstrap-tour/build/js/bootstrap-tour-standalone.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/ColorPickerCss").Include(
                "~/Vendor/mjolnic-bootstrap-colorpicker/dist/css/bootstrap-colorpicker.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/ColorPicker").Include(
              "~/Vendor/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Knob").Include(
              "~/Vendor/jquery-knob/js/jquery.knob.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/EasyPie").Include(
              "~/Vendor/jquery.easy-pie-chart/dist/jquery.easypiechart.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/CropperCss").Include(
                "~/Vendor/cropper/dist/cropper.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Cropper").Include(
              "~/Vendor/cropper/dist/cropper.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
              "~/Vendor/select2/dist/js/select2.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/select2Css").Include(
              "~/Vendor/select2/dist/css/select2.css",
              "~/Vendor/select2-bootstrap-theme/dist/select2-bootstrap.css"
            ));

        }
    }
}