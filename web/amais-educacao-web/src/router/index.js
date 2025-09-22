import { createRouter, createWebHistory } from 'vue-router';
import StudentListView from '../views/StudentListView.vue'; // Aponta para a pasta views
import StudentFormView from '../views/StudentFormView.vue'; // Aponta para a pasta views

const routes = [
  {
    path: '/',
    name: 'StudentList',
    component: StudentListView,
  },
  {
    path: '/student/:ra?',
    name: 'StudentForm',
    component: StudentFormView,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;