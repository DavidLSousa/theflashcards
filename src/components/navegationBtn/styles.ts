import { StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  container: {
    width: "100%",
    alignItems: "center",
  },
  button: {
    backgroundColor: colors.whiteIce,
    padding: 15,
    marginHorizontal: 30,
    marginVertical: 10,
    borderRadius: 8,
    overflow: "hidden",
    elevation: 4,
    shadowColor: '#000',
    maxWidth: 500,
    minWidth: 300,
  },
  buttonText: {
    color: colors.blueMedium,
    fontSize: 20,
    alignSelf: 'center'
  }
})
