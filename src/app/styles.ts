import { StyleSheet } from "react-native"
import { colors } from "@/src/constants/colors"

export const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colors.whiteIce,
  },
  button: {
    backgroundColor: colors.whiteIce,
  },
  buttonsContainer: {
    flex: 1,
    justifyContent: "center",
  },
  scrollContent: {
    flexGrow: 1,
    justifyContent: "center",
    padding: 20,
  },
    form: {
    marginTop: 30,
    gap: 16,
  },
})