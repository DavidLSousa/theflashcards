import { StyleSheet } from "react-native"
import { colors } from "@/src/constants/colors"

export const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colors.whiteIce,
    paddingHorizontal: 20,
  },
  buttonsContainer: {
    flex: 1,
    justifyContent: "center",
  },
  scrollContent: {
    flexGrow: 1,
    justifyContent: "center",
    alignSelf: "center",
    maxWidth: 800,
    width: '100%'
  },
    form: {
    marginTop: 30,
    gap: 16,
  },
})