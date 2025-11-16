import {
  Box,
  Card,
  CardContent,
  Typography,
  Grid,
  Button,
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  useMediaQuery,
  Divider,
} from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { data, useNavigate, useParams } from "react-router-dom";
import { useFetchOrderDetails } from "../../../services/roomServiceService";
import { useEffect, useState } from "react";
import { OrderDetails } from "../../../Interfaces/OrderDetails";
import styles from './style.module.css'

const statusColors: Record<string, string> = {
  Pending: "#f59e0b",
  Completed: "#22c55e",
  Cancelled: "#ef4444",
  InProgress: "#3b82f6",
};

export default function OrderDetailsPage() {
  const { id } = useParams<{ id: string }>();
  const theme = useTheme();
  const isDesktop = useMediaQuery(theme.breakpoints.up("md"));
  const navigate = useNavigate();

  // If no ID in URL → redirect to dashboard
  useEffect(() => {
    if (!id) {
      navigate("/dashboard", { replace: true });
    }
  }, [id, navigate]);

  // Prevent rendering while redirecting
  if (!id) return null;

  const { data: orderDetails, isLoading } = useFetchOrderDetails(id);

  if (isLoading) return <Typography>Loading...</Typography>;

  const total = orderDetails?.items.reduce(
    (sum: number, item: any) => sum + item.price * item.quantity,
    0
  );

  return (
    <>
        {orderDetails && <Box sx={{ p: 2, pb: 10, maxWidth: 900, mx: "auto" }}>
      {/* HEADER */}
      <Typography variant="h5" fontWeight={700}>
        Order #{orderDetails?.orderId.slice(0, 8)}
      </Typography>

      <Box mt={1} display="flex" alignItems="center">
        <span
          className={styles.statusDot}
          style={{ backgroundColor: statusColors[orderDetails.status] }}
        />
        <Typography>{orderDetails?.status}</Typography>
      </Box>

      <Typography color="text.secondary" mt={1} fontSize={14}>
        Created: {new Date(orderDetails?.createdAt).toLocaleString()}
      </Typography>

      <Typography color="text.secondary" fontSize={14}>
        User: {orderDetails?.userId}
      </Typography>

      {/* SUMMARY CARD */}
      <Card sx={{ mt: 3 }}>
        <CardContent>
          <Typography variant="h6" fontWeight={700}>
            Order Summary
          </Typography>

          <Box mt={2}>
            <Typography fontWeight={600}>Order ID:</Typography>
            <Typography color="text.secondary">{orderDetails?.orderId}</Typography>

            <Box mt={2}>
              <Typography fontWeight={600}>User ID:</Typography>
              <Typography color="text.secondary">
                {orderDetails?.userId}
              </Typography>
            </Box>

            {orderDetails?.note && (
              <Box mt={2}>
                <Typography fontWeight={600}>Note:</Typography>
                <Typography color="text.secondary">{orderDetails.note}</Typography>
              </Box>
            )}
          </Box>
        </CardContent>
      </Card>

      {/* ITEMS SECTION */}
      <Typography variant="h6" fontWeight={700} mt={3} mb={1}>
        Items
      </Typography>

      {/* MOBILE LIST */}
      {!isDesktop &&
        orderDetails?.items.map((item: any) => (
          <Box className={styles.itemCard} key={item.id}>
            <Typography fontWeight={600}>{item.itemName}</Typography>

            <Typography fontSize={14} color="text.secondary">
              Price: R {item.price.toFixed(2)}
            </Typography>

            <Typography fontSize={14} color="text.secondary">
              Qty: {item.quantity}
            </Typography>

            <Typography fontSize={14} color="text.secondary">
              Subtotal: R {(item.price * item.quantity).toFixed(2)}
            </Typography>

            {item.note && (
              <Typography fontSize={14} mt={1}>
                Note: {item.note}
              </Typography>
            )}
          </Box>
        ))}

      {/* DESKTOP TABLE */}
      {isDesktop && (
        <Card>
          <CardContent>
            <Table size="small">
              <TableHead>
                <TableRow>
                  <TableCell>Item</TableCell>
                  <TableCell>Price</TableCell>
                  <TableCell>Qty</TableCell>
                  <TableCell>Subtotal</TableCell>
                  <TableCell>Note</TableCell>
                </TableRow>
              </TableHead>

              <TableBody>
                {orderDetails?.items.map((item: any) => (
                  <TableRow key={item.id}>
                    <TableCell>{item.itemName}</TableCell>
                    <TableCell>R {item.price.toFixed(2)}</TableCell>
                    <TableCell>{item.quantity}</TableCell>
                    <TableCell>
                      R {(item.price * item.quantity).toFixed(2)}
                    </TableCell>
                    <TableCell>{item.note || "-"}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>

            <Divider sx={{ my: 2 }} />

            <Typography variant="h6" textAlign="right">
              Total: R {total?.toFixed(2)}
            </Typography>
          </CardContent>
        </Card>
      )}

      {/* ACTION BUTTONS */}
      {/* <Box mt={4} display="flex" flexDirection="column" gap={2}>
        <Button variant="contained" color="success" fullWidth>
          Mark as Completed
        </Button>
        <Button variant="outlined" color="error" fullWidth>
          Cancel Order
        </Button>
      </Box> */}
    </Box>}    
    </>
  );
}