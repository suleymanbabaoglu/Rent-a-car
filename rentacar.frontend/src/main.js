import { createApp } from "vue";
import App from "./App.vue";
import axios from "axios";
import VueAxios from "vue-axios";
import router from "./router";
import "vuetify/styles";
import "@mdi/font/css/materialdesignicons.css";
import { createVuetify } from "vuetify";
import * as components from "vuetify/components";
import * as directives from "vuetify/directives";
import Datepicker from "@vuepic/vue-datepicker";
import "@vuepic/vue-datepicker/dist/main.css";

const app = createApp(App);
const vuetify = createVuetify({
  components,
  directives,
});

app.use(router);
app.use(vuetify, { iconfont: "mdi" });
app.use(VueAxios, axios);
app.provide("axios", app.config.globalProperties.axios);
app.component("Datepicker", Datepicker);

app.mount("#app");
