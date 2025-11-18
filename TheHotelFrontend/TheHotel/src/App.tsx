import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { BrowserRouter, Routes, Route, useNavigate } from 'react-router-dom';
import './App.css'
import LoadingComponent from './components/LoadingComponent/LoadingComponent'
import SplashPage from './app/pages/SplashPage/SplashPage';
import RoomService from './app/pages/RoomServicePage/RoomService';
import Dashboard from './app/pages/DashboardPage/Dashboard';
import Chats from './app/pages/ChatPage/ChatsPage';
import ViewOne from './app/pages/User/ViewOnePage/ViewOne';
import Cart from './app/pages/User/CartPage/Cart';
import BottomNav from './components/BottomNav/BottomNav';
import OrderPlacedUI from './components/TempUIs/OrderPlacedTempUI';
import OrderDetailsPage from './app/pages/OrderDetailsPage/OrderDetailsPage';
import OrdersListPage from './app/pages/OrdersListPage/OrdersListPage';
import { hubConnection } from './services/SignalR/hubConnection';
import { useEffect, useState } from 'react';
import { registerOrderHandlers } from './services/SignalR/orderHub';
import ShowCustomSnackbar from './components/Snackbar/ShowSnackBar';

const queryClient = new QueryClient()

function App() {

  const [buttonText, setButtonText] = useState<string>('');
  const [open, setOpen] = useState<boolean>(false);
  const [showButton, setShowButton] = useState<boolean>(false);
  const [message, setMessage] = useState<string>('');
  const [url, setUrl] = useState<string>('');

  useEffect(() => {
    
  async function ConnectWithsignalR(){
    if (hubConnection.state === "Disconnected") {
    await hubConnection
      .start()
      .then(() => console.log("Signarl Connected"))
      .catch(console.error);

      await hubConnection.invoke("JoinSpecificRoom", '3C9C5A01-41A2-43D5-99E8-10B7CFD508F1')
      .then(() => console.log("Joined room"))
      .catch(console.error);
  }
  }
    ConnectWithsignalR()
    registerOrderHandlers((order) => {
      setButtonText("View")
      setOpen(true)
      setShowButton(true)
      setMessage("Your order has received a new update")
      console.log(order!.orderId);
      
      setUrl(`view/order/${order!.orderId}`)
  });
}, []);

  return (
    <>
     <QueryClientProvider client={queryClient}>
      <BrowserRouter>
      <ShowCustomSnackbar open={open} setOpen={setOpen} message={message} url={url} showButton={showButton} buttonText={buttonText} />
      <Routes>
        {/* <Route path="/" element={<Navbar />}> */}
          <Route index element={<Dashboard/>} />
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="room-service" element={<RoomService />} />
          <Route path="view-one/:id" element={<ViewOne />} />
           <Route path="chats" element={<Chats />} />
           <Route path="view/order/:id" element={<OrderDetailsPage />} />
           <Route path="cart" element={<Cart/>} />
           <Route path="order/success" element={<OrderPlacedUI/>} />
           <Route path="orders" element={<OrdersListPage/>} />
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
