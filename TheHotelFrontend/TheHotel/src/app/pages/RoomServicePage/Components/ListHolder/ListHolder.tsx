import { List, ListSubheader } from "@mui/material";
import styles from './ListHolder.module.css'
import { useNavigate } from "react-router-dom";
import { useFetchProducts } from "../../../../../services/productService";
import { useEffect, useState } from "react";
import { Product } from "../../../../../Interfaces/products";
import { MdAddShoppingCart } from "react-icons/md";

export default function ListHolder(){
const img = 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Lionel_Messi_NE_Revolution_Inter_Miami_7.9.25-055.jpg/250px-Lionel_Messi_NE_Revolution_Inter_Miami_7.9.25-055.jpg'
  const [products, setProducts] = useState<Product[]>([]);
const navigate = useNavigate();

const {data:allProducts, isSuccess} = useFetchProducts();

  if(isSuccess){
    // setProducts(allProducts)
    
    
  }
// console.log(allProducts);
 useEffect(()=>{
//   // getAllProducts().then((res) => {
//   //   setProducts(res.data);
//   // });

  if(isSuccess){
    setProducts(allProducts)
    console.log("d");
    
  }
  },[isSuccess])

    
    return (
        <List
      sx={{
        width: '100%',
        // maxWidth: 360,
        bgcolor: 'background.paper',
        position: 'relative',
        overflow: 'auto',
        // maxHeight: 900,
        '& ul': { padding: 0 },
      }}
      subheader={<li />}
    >
      {[0].map((sectionId) => (
        <li key={`section-${sectionId}`}>
          <ul>
            <ListSubheader>{`I'm sticky ${sectionId}`}</ListSubheader>
            <div className={styles.ItemHolder}>
              {products.map((product) => (
                <div className={styles.listItem}  key={`${product.id}`}>
                    <div onClick={()=>{navigate(`/view-one/${product.id}`)}} className={styles.menuItem4}>
                      <label className={styles.promo}>Out of Stock</label>
                      <div className={styles.menuItem2}>

                          <div style={{backgroundImage:`url(${img}`}} className={styles.imgho}>
                              {/* <img className={styles.mainlogo2} src={restaurantBanner}/> */}
                          </div>
                          
                          <div className={styles.prodtext}>
                              <label>{product.itemName}</label>

                              <div className={styles.pchold}>
                                  <div className={styles.pr}>
                                      <label className={styles.price}>R{product.price}</label>
                                      {/* <label className={styles.price}>R</label>
                                      <label  className={styles.price}>R</label> */}
                                  </div>
                                  <button className={styles.actionbtn}  type="button">
                                      <MdAddShoppingCart />
                                  </button>
                              </div>
                              
                          </div>
                          <label className={styles.promoLabel}>Promotion!</label>
                          
                      </div>
                      
                  </div>
                </div>
              ))}
            </div>
            
          </ul>
        </li>
      ))}
    </List>
    );
}