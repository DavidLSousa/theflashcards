import { StyleSheet } from 'react-native';
import { colors } from '@/src/constants/colors';

export const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    flexWrap: 'wrap',
    backgroundColor: colors.whiteIce,
    padding: 5,
    paddingBottom: 10,
    borderTopLeftRadius: 8,
    borderTopRightRadius: 8,
    marginBottom: -8,
    width: '100%'
  },
  button: {
    paddingHorizontal: 12,
    paddingVertical: 8,
    margin: 3,
    backgroundColor: colors.whiteIce,
    borderRadius: 6,
    elevation: 2,
    shadowColor: '#000',
    shadowOpacity: 0.1,
    shadowRadius: 2,
    shadowOffset: { width: 0, height: 1 },
  },
  buttonText: {
    fontWeight: 'bold',
    color: colors.blueDark,
    fontSize: 14,
  },
});