export interface CustomerResponse {
  customerId: string
  companyName: string
  contactName: string
  contactTitle: string
  address: string
  city: string
  region: any
  postalCode: string
  country: string
  phone: string
  fax: string
  orders: any[]
}
export interface CustomerIdsListResponse {
  customerIds: string[]
}
