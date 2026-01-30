import { Box, Typography, Grid } from "@mui/material";
import ActivitiesCard from "./Components/ActivitiesCard";
import LoadingComponent from "../../../components/LoadingComponent/LoadingComponent";
import { useEffect, useState } from "react";

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
      "https://media-cdn.tripadvisor.com/media/attractions-splice-spp-674x446/07/80/fe/a1.jpg",
    description:
      "Taste world-class wines and explore the stunning Cape Winelands.",
  },
  {
    title: "Shark Cage Diving",
    subtitle: "Gansbaai, 2 hours away",
    image:
      "https://media-cdn.tripadvisor.com/media/attractions-splice-spp-674x446/15/52/a3/f5.jpg",
    description:
      "Get up close with great white sharks in a safe, unforgettable underwater experience.",
  },
  {
    title: "Table Mountain Hike",
    subtitle: "Full Day Adventure",
    image:
      "https://insideguide.co.za/cape-town/app/uploads/2018/05/india-venster.png",
    description:
      "Hike one of the world's 7 natural wonders with breathtaking views of Cape Town.",
  },
];

export default function ActivitiesPage() {
  const [isLoading, setLoading] = useState<boolean>(true);

    useEffect(()=>{
      window.scrollTo(0, 0);
    setTimeout(() => {
      setLoading(false)
    }, 2000)
  },[]);
  return (
    <>
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
        adventures, all within reach of your stay.
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
    {isLoading && <LoadingComponent message={"Let's find you something to do"}/>}
    </>
    
  );
}
