import {
  Box,
  Grid,
  Card,
  CardContent,
  Typography
} from "@mui/material";
import { useEffect, useState } from "react";
import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  Tooltip,
  PieChart,
  Pie,
  Cell,
  LineChart,
  Line,
  CartesianGrid,
  ResponsiveContainer,
} from "recharts";
import { getOrdersData, getProductsData } from "../../../../services/AnalyseService/analyseService";
import { Product } from "../../../../Interfaces/products";
import { OrderDetails } from "../../../../Interfaces/OrderDetails";

const COLORS = ["#3470ed", "#62a3ff", "#89b9ff", "#aecfff", "#d3e5ff"];

export default function AnalyticsPage() {

  const [orders, setOrders] = useState<OrderDetails[]>();
  const [_menu, setMenu] = useState<Product[]>();

  useEffect(()=> {
    const getData = async () =>{
        const res = await getProductsData();

        if(res.status == 200){
            setMenu(res.data)
        }

        const resp = await getOrdersData();

        if(resp.status == 200){
            setOrders(resp.data)
        }
    }

    getData()
  },[])



  const totalRevenue = orders?.reduce(
    (sum, o) => sum + o.items.reduce((s, i) => s + i.price * i.quantity, 0),
    0
  );

  const totalOrders = orders?.length;

  
  const countMap: Record<string, number> = {};
  orders?.forEach(o =>
    o.items.forEach(i => {
      countMap[i.itemName] = (countMap[i.itemName] || 0) + i.quantity;
    })
  );
  const mostBought = Object.entries(countMap).sort((a, b) => b[1] - a[1])[0];

  const revenueByDay: Record<string, number> = {};
  orders?.forEach(o => {
    const day = o.createdAt.split("T")[0];
    revenueByDay[day] =
      (revenueByDay[day] || 0) +
      o.items.reduce((s, i) => s + i.price * i.quantity, 0);
  });

  const revenueChartData = Object.entries(revenueByDay).map(([date, value]) => ({
    date,
    revenue: Number(value.toFixed(2)),
  }));

  
  const topItemsChart = Object.entries(countMap).map(([name, qty]) => ({
    name,
    qty,
  }));

  
  const pieData = Object.entries(countMap).map(([name, qty]) => ({
    name,
    value: qty,
  }));

  return (
    <Box sx={{ p: 4 }}>
      <Typography variant="h4" fontWeight={700} mb={3}>
        Analytics Dashboard
      </Typography>

      {/* KPI CARDS */}
      <Grid container spacing={3} columns={12} mb={4}>
  <Grid size={{ xs: 12, md: 3 }}>
    <Card>
      <CardContent>
        <Typography fontSize={14} color="text.secondary">
          Total Revenue
        </Typography>
        <Typography variant="h5" fontWeight={700}>
          R {totalRevenue?.toFixed(2)}
        </Typography>
      </CardContent>
    </Card>
  </Grid>

  <Grid size={{ xs: 12, md: 3 }}>
    <Card>
      <CardContent>
        <Typography fontSize={14} color="text.secondary">
          Total Orders
        </Typography>
        <Typography variant="h5" fontWeight={700}>
          {totalOrders}
        </Typography>
      </CardContent>
    </Card>
  </Grid>

  <Grid size={{ xs: 12, md: 3 }}>
    <Card>
      <CardContent>
        <Typography fontSize={14} color="text.secondary">
          Most Purchased
        </Typography>
        <Typography variant="h6" fontWeight={700}>
          {mostBought?.[0] ?? "-"}
        </Typography>
      </CardContent>
    </Card>
  </Grid>

  <Grid size={{ xs: 12, md: 3 }}>
    <Card>
      <CardContent>
        <Typography fontSize={14} color="text.secondary">
          Highest Value Customer
        </Typography>
        <Typography variant="h6" fontWeight={700}>
          Coming soon…
        </Typography>
      </CardContent>
    </Card>
  </Grid>
</Grid>


{/* CHARTS */}
<Grid container spacing={4} columns={12}>

  {/* FULL WIDTH LINE CHART */}
  <Grid size={12}>
    <Card sx={{ height: 420, pb:2, display: "flex", flexDirection: "column" }}>
      <CardContent sx={{ flex: 1 }}>
        <Typography variant="h6" mb={2}>
          Revenue Over Time
        </Typography>
        <ResponsiveContainer width="100%" height="100%">
          <LineChart data={revenueChartData}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="date" />
            <YAxis />
            <Tooltip />
            <Line type="monotone" dataKey="revenue" stroke="#3470ed" strokeWidth={3} />
          </LineChart>
        </ResponsiveContainer>
      </CardContent>
    </Card>
  </Grid>

  {/* PIE CHART (LEFT HALF) */}
  <Grid size={{ xs: 12, md: 6 }}>
    <Card sx={{ height: 420, display: "flex", flexDirection: "column" }}>
      <CardContent sx={{ flex: 1 }}>
        <Typography variant="h6" mb={2}>
          Sales Distribution
        </Typography>
        <ResponsiveContainer width="100%" height="100%">
          <PieChart>
            <Pie
              data={pieData}
              dataKey="value"
              nameKey="name"
              label
            >
              {pieData.map((_, i) => (
                <Cell key={i} fill={COLORS[i % COLORS.length]} />
              ))}
            </Pie>
          </PieChart>
        </ResponsiveContainer>
      </CardContent>
    </Card>
  </Grid>

  {/* BAR CHART (RIGHT HALF) */}
  <Grid size={{ xs: 12, md: 6 }}>
    <Card  sx={{ height: 420, pb:2, display: "flex", flexDirection: "column" }}>
      <CardContent sx={{ flex: 1 }}>
        <Typography variant="h6" mb={2}>
          Top Selling Items
        </Typography>
        <ResponsiveContainer width="100%" height="100%">
          <BarChart data={topItemsChart} layout="vertical">
            <XAxis type="number" />
            <YAxis dataKey="name" type="category" width={120} />
            <Tooltip />
            <Bar dataKey="qty" fill="#3470ed" />
          </BarChart>
        </ResponsiveContainer>
      </CardContent>
    </Card>
  </Grid>

</Grid>
    </Box>
  );
}
