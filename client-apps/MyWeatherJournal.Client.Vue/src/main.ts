import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { FontAwesomeIcon } from './plugins/fontawesome';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';     // For bootstrap javascript

import './assets/styles.scss';



const app = createApp(App)

// This is a "global registration" for font awesome, so that it is accessible app-wide
app.component('font-awesome-icon', FontAwesomeIcon)

app.use(router)
app.mount('#app')
