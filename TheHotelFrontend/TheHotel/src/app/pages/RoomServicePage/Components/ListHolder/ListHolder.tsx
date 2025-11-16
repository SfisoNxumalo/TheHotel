import { List, ListSubheader } from "@mui/material";
import styles from './ListHolder.module.css'
import { useNavigate } from "react-router-dom";
import { useFetchProducts } from "../../../../../services/productService";
import { useEffect, useState } from "react";
import { Product } from "../../../../../Interfaces/products";
import { MdAddShoppingCart } from "react-icons/md";
import { useCartStore } from "../../../../../stores/cartStore";
import { CartItem } from "../../../../../Interfaces/CartItem";

export default function ListHolder(){
const img = 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Lionel_Messi_NE_Revolution_Inter_Miami_7.9.25-055.jpg/250px-Lionel_Messi_NE_Revolution_Inter_Miami_7.9.25-055.jpg'
  const [products, setProducts] = useState<Product[]>([]);
const navigate = useNavigate();

const {data:allProducts, isSuccess} = useFetchProducts();
const addToCart = useCartStore((state) => state.addItem)

const handleAddToCart = (menuItem:Product) => {

  if(!menuItem?.id) return
  
  const item: CartItem = { 
        id: menuItem.id,
        itemName: menuItem.itemName,
        price: menuItem.price,
        quantity: 1, 
        image: menuItem.image,
        note:'' 
  };

  addToCart(item);
};

 useEffect(()=>{
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
                    <div className={styles.menuItem4}>
                      {!product.available && <label className={styles.promo}>Out of Stock</label>}
                      <div className={styles.menuItem2}>

                          <div onClick={()=>{navigate(`/view-one/${product.id}`)}} style={{backgroundImage:`url(${img}`}} className={styles.imgho}>
                              {/* <img className={styles.mainlogo2} src={restaurantBanner}/> */}
                          </div>
                          
                          <div className={styles.prodtext}>
                              <label onClick={()=>{navigate(`/view-one/${product.id}`)}}>{product.itemName}</label>

                              <div className={styles.pchold}>
                                  <div onClick={()=>{navigate(`/view-one/${product.id}`)}} className={styles.pr}>
                                      <label className={styles.price}>R{product.price}</label>
                                      {/* <label className={styles.price}>R</label>
                                      <label  className={styles.price}>R</label> */}
                                  </div>
                                  <button onClick={()=>handleAddToCart(product)} className={styles.actionbtn}  type="button">
                                      <MdAddShoppingCart />
                                  </button>
                              </div>
                              
                          </div>
                          {/* <label className={styles.promoLabel}>Promotion!</label> */}
                          
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