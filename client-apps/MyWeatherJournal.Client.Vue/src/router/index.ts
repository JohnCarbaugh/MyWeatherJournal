import { createRouter, createWebHistory } from 'vue-router'

import Weather from '../views/Weather.vue'
import Journal from '../views/Journal.vue'
import Community from '../views/Community.vue'

const routes = [
  { path: '/', redirect: '/weather' },
  { path: '/weather', name: 'Weather', component: Weather },
  { path: '/journal', name: 'Journal', component: Journal },
  { path: '/community', name: 'Community', component: Community }
]

// TODO: Look up lazy-loading chunks
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
