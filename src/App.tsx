import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css'
import LoadingComponent from './components/LoadingComponent/LoadingComponent'
import SplashPage from './app/pages/SplashPage/SplashPage';
import RoomService from './app/pages/RoomServicePage/RoomService';
import Dashboard from './app/pages/DashboardPage/Dashboard';
import Chats from './app/pages/ChatPage/ChatsPage';
import ViewOne from './app/pages/ViewOnePage/ViewOne';
import Cart from './app/pages/CartPage/Cart';
import BottomNav from './components/BottomNav/BottomNav';

const queryClient = new QueryClient()

function App() {

  return (
    <>
     <QueryClientProvider client={queryClient}>
      <BrowserRouter>
      <Routes>
        {/* <Route path="/" element={<Navbar />}> */}
          <Route index element={<Dashboard/>} />
          <Route path="cashboard" element={<Dashboard />} />
          <Route path="room-service" element={<RoomService />} />
          <Route path="view-one/:id" element={<ViewOne />} />
           <Route path="chats" element={<Chats />} />
           <Route path="cart" element={<Cart/>} />
          <Route path="*" element={<Dashboard/>} />
        {/* </Route> */}
      </Routes>
      <BottomNav/>
    </BrowserRouter>
    </QueryClientProvider>
    
    </>
  )
}

export default App
