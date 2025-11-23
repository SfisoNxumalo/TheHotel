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
import { registerMessageHandlers } from './services/SignalR/messageHub';
import { SnackbarOrigin } from '@mui/material';
import { useMessageStore } from './stores/messageStore';
import LoginPage from './app/pages/LoginPage/LoginPage';
import RegisterPage from './app/pages/RegisterPage/RegisterPage';
import { useAuthStore } from './stores/authStore';
import AnalyticsPage from './app/pages/Staff/AnalyticsPage/AnalyticsPage';
import AdminChats from './app/pages/AdminChat/AdminChatsPage';
import BottomNavSpacer from './components/BottomNav/BottomNavSpacer';
import ActivitiesPage from './app/pages/ActivitiesPage/ActivitiesPage';

const queryClient = new QueryClient()

function App() {

  const [buttonText, setButtonText] = useState<string>('');
  const [open, setOpen] = useState<boolean>(false);
  const [showButton, setShowButton] = useState<boolean>(false);
  const [message, setMessage] = useState<string>('');
  const [anchorOrigin, setAnchorOrigin] = useState<SnackbarOrigin>({ vertical: 'bottom', horizontal: 'left', });
  const [url, setUrl] = useState<string>('');

  const addMessage = useMessageStore(s => s.addMessage);
  const user = useAuthStore((s) => s.user);
  
  useEffect(() => {
    
  async function ConnectWithsignalR(){
    if (hubConnection.state === "Disconnected") {
      await hubConnection
        .start()
        .then()
        .catch(console.error);

      await hubConnection.invoke("JoinSpecificRoom", `${user?.id}`)
      .then()
      .catch(console.error);
    }
  }

    if(user?.id){
      ConnectWithsignalR()
      
      
    registerOrderHandlers((order) => {
      setButtonText("View")
      setOpen(true)
      setShowButton(true)
      setMessage("Your order has received a new update")
      setAnchorOrigin({ vertical: 'bottom', horizontal: 'left' })
      setUrl(`view/order/${order!.orderId}`)
    });

    registerMessageHandlers((message) => {
      if(message.senderId != user?.id){
        setMessage(`New Message: "${message.messageText}"`)
        setAnchorOrigin({ vertical: 'top', horizontal: 'center', })
        setOpen(true)
        addMessage(message)
      }
    });
    }
}, [user]);

  return (
    <div className='div-ver'>
      <QueryClientProvider client={queryClient}>
      <BrowserRouter>

      <ShowCustomSnackbar open={open} setOpen={setOpen} 
      message={message} url={url} 
      showButton={showButton} buttonText={buttonText} 
      anchorOrigin={anchorOrigin} />
      
      <Routes>
        {/* <Route path="/" element={<Navbar />}> */}
          <Route index element={<LoginPage/>} />
          <Route path="dashboard" element={<Dashboard />} />
           <Route path="auth/login" element={<LoginPage />} />
          <Route path="auth/register" element={<RegisterPage />} />
          <Route path="room-service" element={<RoomService />} />
          <Route path="view-one/:id" element={<ViewOne />} />
           <Route path="chats" element={<Chats />} />
           <Route path="admin/chats" element={<AdminChats />} /> //admin
           <Route path="view/order/:id" element={<OrderDetailsPage />} />
           <Route path="cart" element={<Cart/>} />
           <Route path="order/success" element={<OrderPlacedUI/>} />
           <Route path="orders" element={<OrdersListPage/>} />
           <Route path="data/analyse" element={<AnalyticsPage/>} /> //admin
           <Route path="activities" element={<ActivitiesPage/>} /> 
          <Route path="*" element={<LoginPage/>} />
        {/* </Route> */}
      </Routes>
      {/* <BottomNavSpacer/> */}
      {user?.id && <BottomNav/>}
    </BrowserRouter>
    </QueryClientProvider>
    </div>
  )
}

export default App
