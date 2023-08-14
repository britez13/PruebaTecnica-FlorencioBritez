import { createRouter, createWebHistory } from "vue-router";

const routes = [
    { path: "/", component: () => import("../pages/Home.vue") },
    { path: "/game", component: () => import("../pages/Game.vue") },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router