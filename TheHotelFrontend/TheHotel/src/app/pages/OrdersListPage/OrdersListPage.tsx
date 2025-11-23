import {
  Box,
  Card,
  CardContent,
  Typography,
  Button,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  useMediaQuery,
} from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { useNavigate } from "react-router-dom";
import { useFetchAllOrders } from "../../../services/roomServiceService";
import { useAuthStore } from "../../../stores/authStore";

const statusColors: Record<string, string> = {
  Pending: "#f59e0b",
  Completed: "#22c55e",
  Cancelled: "#ef4444",
  InProgress: "#3b82f6",
};

export default function OrdersListPage() {
  const theme = useTheme();
  const isDesktop = useMediaQuery(theme.breakpoints.up("md"));
  const navigate = useNavigate();

  const user = useAuthStore((s) => s.user);

  const { data: orders, isLoading } = useFetchAllOrders(`${user?.id}`);

  if (isLoading) return <Typography>Loading orders...</Typography>;

  const getTotal = (items: any[]) =>
    items.reduce((sum, item) => sum + item.price * item.quantity, 0);

  return (
    <Box sx={{ p: 2, pb:0, maxWidth: 900, mx: "auto" }}>
      <Typography variant="h5" fontWeight={700} mb={3}>
        Orders
      </Typography>

      {/* MOBILE FIRST CARDS */}
      {!isDesktop && orders?.length &&
        orders?.map((order: any) => (
          <Card
            key={order.orderId}
            sx={{ mb: 2, cursor: "pointer" }}
            onClick={() => navigate(`/view/order/${order.orderId}`)}>
            <CardContent>
              <Box display="flex" alignItems="center" mb={1}>
                <span
                  className="status-dot"
                  style={{ backgroundColor: statusColors[order.status] }}
                />
                <Typography fontWeight={600}>{order.status}</Typography>
              </Box>

              <Typography fontWeight={700}>
                Order #{order.orderId.slice(0, 8)}
              </Typography>

              <Typography color="text.secondary" fontSize={14}>
                Created: {new Date(order.createdAt).toLocaleString()}
              </Typography>

              <Typography color="text.secondary" fontSize={14}>
                Items: {order.items.length}
              </Typography>

              <Typography fontWeight={600} mt={1}>
                Total: R {getTotal(order.items).toFixed(2)}
              </Typography>
            </CardContent>
          </Card>
        ))}

      {/* DESKTOP TABLE */}
      {isDesktop && (
        <Card>
          <CardContent>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Status</TableCell>
                  <TableCell>Order ID</TableCell>
                  <TableCell>User ID</TableCell>
                  <TableCell>Items</TableCell>
                  <TableCell>Total</TableCell>
                  <TableCell>Created</TableCell>
                  <TableCell>Action</TableCell>
                </TableRow>
              </TableHead>

              <TableBody>
                {orders?.map((order: any) => (
                  <TableRow key={order.orderId}>
                    <TableCell>
                      <Box display="flex" alignItems="center">
                        <span
                          className="status-dot"
                          style={{
                            backgroundColor: statusColors[order.status],
                          }}
                        />
                        {order.status}
                      </Box>
                    </TableCell>

                    <TableCell>{order.orderId}</TableCell>
                    <TableCell>{order.userId}</TableCell>
                    <TableCell>{order.items.length}</TableCell>

                    <TableCell>
                      R {getTotal(order.items).toFixed(2)}
                    </TableCell>

                    <TableCell>
                      {new Date(order.createdAt).toLocaleString()}
                    </TableCell>

                    <TableCell>
                      <Button
                        variant="outlined"
                        onClick={() =>
                          navigate(`/orders/${order.orderId}`)
                        }
                      >
                        View
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </CardContent>
        </Card>
      )}
    </Box>
  );
}
