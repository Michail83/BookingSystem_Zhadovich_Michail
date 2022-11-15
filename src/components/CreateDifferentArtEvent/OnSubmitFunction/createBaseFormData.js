export const createBaseFormData = (data) => {
    const formData = new FormData();
    formData.append('EventName', data.eventName);
    formData.append('Date', data.date);
    formData.append('AmountOfTickets', data.amountOfTickets);
    formData.append('Place', data.place);
    formData.append('Price', data.price);
    formData.append('Latitude', data.latitude);
    formData.append('Longitude', data.longitude);
    
    return formData;

}
