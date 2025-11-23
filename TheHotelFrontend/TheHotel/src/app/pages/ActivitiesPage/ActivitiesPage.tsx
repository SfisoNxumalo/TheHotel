import { Box, Typography, Grid, Card, CardMedia } from "@mui/material";
import ActivitiesCard from "./Components/ActivitiesCard";


const mockActivities = [
  {
    title: "Sunset Beach Walk",
    subtitle: "Daily at 6:00 PM",
    image:
      "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?auto=format&fit=crop&w=900&q=60",
    description:
      "Enjoy a relaxing walk along the coastline as the sun sets beautifully over the ocean.",
  },
  {
    title: "Wine Tasting Tour",
    subtitle: "Somerset West, 15 minutes away",
    image:
      "https://images.unsplash.com/photo-1592861956120-e524fc739727?auto=format&fit=crop&w=900&q=60",
    description:
      "Taste world-class wines and explore the stunning Cape Winelands.",
  },
  {
    title: "Shark Cage Diving",
    subtitle: "Gansbaai, 2 hours away",
    image:
      "https://images.unsplash.com/photo-1578496781983-2f88e17efb0a?auto=format&fit=crop&w=900&q=60",
    description:
      "Get up close with great white sharks in a safe, unforgettable underwater experience.",
  },
  {
    title: "Table Mountain Hike",
    subtitle: "Full Day Adventure",
    image:
      "https://images.unsplash.com/photo-1544986581-efac024faf62?auto=format&fit=crop&w=900&q=60",
    description:
      "Hike one of the world's 7 natural wonders with breathtaking views of Cape Town.",
  },
];

export default function ActivitiesPage() {
  return (
    <Box sx={{ p: 4, maxWidth: 1200, mx: "auto" }}>

      {/* PAGE HEADER */}
      <Typography
        variant="h4"
        fontWeight={800}
        mb={1}
        sx={{ textAlign: "center" }}
      >
        Things To Do Around The Hotel
      </Typography>

      <Typography
        variant="body1"
        color="text.secondary"
        mb={5}
        sx={{ textAlign: "center", maxWidth: 700, mx: "auto" }}
      >
        Discover exciting experiences, relaxing activities, and unforgettable
        adventures — all within reach of your stay.
      </Typography>

      {/* ACTIVITIES GRID */}
      <Grid container spacing={4} columns={12}>
        {mockActivities.map((a, i) => (
          <Grid size={{ xs: 12, sm: 6, md: 4 }} key={i}>
            <ActivitiesCard
              title={a.title}
              subtitle={a.subtitle}
              image={a.image}
              description={a.description}
            />
          </Grid>
        ))}
      </Grid>
    </Box>
  );
}
