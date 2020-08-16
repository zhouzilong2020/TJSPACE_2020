
const routes = [
  {
    path: '/',
    component: () => import('layouts/BBSHomePageLayout.vue'),
    children: [
      { path: 'BBSHomePage', component: () => import('pages/BBSHomePage.vue') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
