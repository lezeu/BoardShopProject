import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'
import UpdateProduct from '../views/UpdateProduct.vue'
import AddProduct from '../views/AddProduct.vue'
import GetProductAdmin from '../views/GetProductAdmin.vue'
import GetProduct from '../views/GetProduct.vue'
import LogIn from '../views/LogIn.vue'
import SignUp from '../views/SignUp.vue'
import Cart from '../views/Cart.vue'
import Logged from '../components/HelloLogged'
import Favourite from '../views/Favourite.vue'
import CheckOut from '../views/CheckOut.vue'
//import CartAdd from '../views/CartAdd.vue'
Vue.use(VueRouter)

const routes = [

  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/Product/update/:id',
    name: 'update',
    component: UpdateProduct
  },
  {
    path: '/Product',
    name: 'add',
    component: AddProduct
  },
  {
    path: '/Product/get',
    name: 'get',
    component: GetProductAdmin
  },
  {
    path: '/Product/ViewProducts',
    name: 'get',
    component: GetProduct
  },
  {
    path: '/LogIn',
    name: 'LogIn',
    component: LogIn
  },
  {
    path: '/signup',
    name: 'signup',
    component: SignUp
  },
  {
    path: '/Cart',
    name: 'Cart',
    component: Cart
  },
  {
    path: '/logged',
    name: 'HelloLogged',
    component: Logged
  },
  {
    path: '/Fav',
    name: 'Favourite',
    component: Favourite
  },
  {
    path: '/Order',
    name: 'CheckOut',
    component: CheckOut
  },
  // {
  //   path: '/Cart/:id/:productName/:category/:price/:shopType',
  //   name: 'cartAdd',
  //   component: CartAdd
  // },
    
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
