const FormComponent = () => {

const getValueFromInput = (formData) => {
  console.log(formData.get("firstname"));
  console.log(formData.get("lastname"));
}
  return ( 
      <>
          <form action={getValueFromInput}>
              <div>
              <label htmlFor="firstname">Firstname</label>
              <input type="text" name='firstname' />
              </div>
              <div>
              <label htmlFor="lastname">Lastname</label>
              <input type="text" name='lastname' />
              </div>
              <button type='submit'>Valider</button>
          </form>
      </>
   );
}

export default FormComponent;