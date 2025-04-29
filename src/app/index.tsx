import { View, StyleSheet } from "react-native";
import { LinearGradient } from "expo-linear-gradient";

import Header from "@/src/components/header";
import { colors } from "../constants/colors";

export default function Index() {
  return (
    <LinearGradient 
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <Header />
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colors.whiteIce,
  },
})