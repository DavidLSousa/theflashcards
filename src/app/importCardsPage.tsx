import { LinearGradient } from "expo-linear-gradient";
import Header from "@/src/components/header";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

export default function ImportCardsPage() {
  return (
    <LinearGradient 
          colors={[colors.blueLazuli, colors.blueMedium]}
          style={styles.container}
        >
          <Header />
    </LinearGradient>
  );
}